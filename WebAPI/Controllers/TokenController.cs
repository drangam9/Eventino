using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAPI.Controllers
{
	public class TokenController : Controller
	{
		private readonly IConfiguration _configuration;

		public TokenController(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		[HttpGet("token")]
		public IActionResult GetToken()
		{
			var claims = new[]
			{
		new Claim(ClaimTypes.NameIdentifier, "John"),
		new Claim(ClaimTypes.Role, "Admin")
	};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: _configuration["Jwt:Issuer"],
				audience: _configuration["Jwt:Audience"],
				claims: claims,
				expires: DateTime.Now.AddMinutes(1),
				signingCredentials: creds);

			return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
		}
	}
}
