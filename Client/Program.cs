using Blazored.LocalStorage;
using Frontend.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using System.Security.Claims;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("api", client => client.BaseAddress = new Uri("https://localhost:7027"))
	.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
builder.Services.AddBlazoredLocalStorageAsSingleton();


// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("api"));
builder.Services.AddScoped<DialogService>();

builder.Services.AddMsalAuthentication(options =>
{
	builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
	options.ProviderOptions.DefaultAccessTokenScopes.Add("api://3713d708-de0b-4266-a1d7-33f13fc43ec7/scope");
	options.ProviderOptions.Cache.CacheLocation = "localStorage";
	options.UserOptions.RoleClaim = "roles";

}).AddAccountClaimsPrincipalFactory<ExampleClaimsPrincipalFactory<RemoteUserAccount>>();


await builder.Build().RunAsync();

public class ExampleClaimsPrincipalFactory<TAccount> : AccountClaimsPrincipalFactory<TAccount>
  where TAccount : RemoteUserAccount
{
	public ExampleClaimsPrincipalFactory(IAccessTokenProviderAccessor accessor)
	: base(accessor)
	{
		//Any dependency injection or construction of objects 
		//inside this constructor usually leads to wasm memory exceptions
	}

	public async override ValueTask<ClaimsPrincipal> CreateUserAsync(TAccount account, RemoteAuthenticationUserOptions options)
	{
		var user = await base.CreateUserAsync(account, options);

		if (account != null)
		{

			var identity = user.Identity as ClaimsIdentity;

			var preferred_username = identity.FindFirst("preferred_username")?.Value;
			if (preferred_username == "drangam9@gmail.com")
			{
				identity.AddClaim(new Claim("roles", "administrator"));
			}
		}

		return user;
	}
}