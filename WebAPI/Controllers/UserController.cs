using BusinessLayer.Contracts;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebAPI.Dto;
namespace WebAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController : Controller
	{
		private readonly IUserService _userService;
		private readonly ILogger<UserController> _logger;

		public UserController(IUserService userService, ILogger<UserController> logger)
		{
			_userService = userService;
			_logger = logger;
		}

		[HttpGet]
		[SwaggerOperation(Summary = "Get all users")]
		public IActionResult Get()
		{
			var users = _userService.GetAllUsers();
			_logger.LogInformation("Get all users");
			return Ok(users);
		}

		[HttpGet]
		[Route("{userId}")]
		[SwaggerOperation(Summary = "Get a user by its Guid")]
		public IActionResult Get([FromRoute] Guid userId)
		{
			var user = _userService.GetUserById(userId);
			return Ok(user);
		}

		[HttpGet]
		[Route("entra/{entraId}")]
		[SwaggerOperation(Summary = "Get a user by the oid from the EntraId token provided when logging in")]
		public IActionResult GetByEntraId([FromRoute] Guid entraId)
		{
			var user = _userService.GetUserIdByEntraId(entraId);
			return Ok(user);
		}

		[HttpPost]
		[Authorize]
		[SwaggerOperation(Summary = "Add a new user")]
		public IActionResult Post([FromBody] UserDto user)
		{
			User newUser = new()
			{
				EntraOid = user.EntraOid,
				Email = user.Email,
				Name = user.Name,
			};
			_userService.CreateUser(newUser);
			return Ok();
		}

		[HttpPut]
		[Authorize(Roles = "administrator")]
		[SwaggerOperation(Summary = "Update a user")]
		public IActionResult Put([FromBody] UserDto user)
		{
			User updatedUser = new()
			{
				EntraOid = user.EntraOid,
				Email = user.Email,
				Name = user.Name,
			};
			_userService.UpdateUser(updatedUser);
			return Ok();
		}

		[HttpDelete("{userId}")]
		[Authorize(Roles = "administrator")]
		[SwaggerOperation(Summary = "Delete a user")]
		public IActionResult Delete([FromRoute] Guid userId)
		{
			_userService.DeleteUser(userId);
			return Ok();
		}
	}
}
