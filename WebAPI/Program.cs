
using BusinessLayer.Contracts;
using BusinessLayer.Services;
using DataAccessLayer;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Serilog;
using System.Net;
using System.Threading.RateLimiting;

namespace WebAPI
{
	public static class Program
	{
		private static readonly string[] middleware = new string[] { "Accept-Encoding" };

		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			//Logger
			builder.Logging.AddSerilog(new LoggerConfiguration().WriteTo.Console().WriteTo.File("log.txt", rollOnFileSizeLimit: true).CreateLogger());

			// Add services to the container.
			builder.Services.AddCors(o => o.AddDefaultPolicy(_ => _.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
			builder.Services.AddAuthorization();
			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen(options =>
			{
				options.EnableAnnotations();
				options.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "Event Management API",
					Description = "An ASP.NET Core Web API for managing events, users, tickets, and other related data.",
				});
			}
				);

			//Repository
			builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

			//Services
			builder.Services.AddScoped(typeof(IUserService), typeof(UserService));
			builder.Services.AddScoped(typeof(IEventService), typeof(EventService));
			builder.Services.AddScoped(typeof(ITicketService), typeof(TicketService));

			//Database
			builder.Services.AddDbContext<MyDbContext>();

			builder.Services.AddRateLimiter(_ => _.AddFixedWindowLimiter(policyName: "fixed", options =>
			{
				options.PermitLimit = 4;
				options.Window = TimeSpan.FromSeconds(12);
				options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
				options.QueueLimit = 2;
			}));

			builder.Services.AddResponseCaching();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseExceptionHandler(appError =>
			{
				appError.Run(async context =>
				{
					context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
					context.Response.ContentType = "application/json";

					var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
					if (contextFeature != null)
					{
						await context.Response.WriteAsync(JsonConvert.SerializeObject(new
						{
							StatusCode = context.Response.StatusCode,
							Message = "Internal Server Error."
						}));
					}
				});
			});
			app.UseHttpsRedirection();
			app.UseCors();
			app.UseRateLimiter();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseResponseCaching();

			app.Use(async (context, next) =>
			{
				context.Response.GetTypedHeaders().CacheControl =
					new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
					{
						Public = true,
						MaxAge = TimeSpan.FromSeconds(10)
					};
				context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
middleware;

				await next();
			});

			app.MapControllers().RequireRateLimiting("fixed");

			app.Run();
		}
	}
}
