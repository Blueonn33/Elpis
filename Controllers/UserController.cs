using Elpis.Business.Services.Interfaces;
using Elpis.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Elpis.Controllers
{
	[ApiController]
	[Authorize]
	public class UserController : ControllerBase
	{
		private readonly AuthenticationStateProvider _authenticationStateProvider;
		private readonly IUsersService _usersService;
		private readonly UserManager<User> _userManager;

		public UserController(IUsersService userService, UserManager<User> userManager,
			AuthenticationStateProvider authenticationStateProvider)
		{
			_usersService = userService;
			_userManager = userManager;
			_authenticationStateProvider = authenticationStateProvider;
		}

		[HttpGet]
		[Route("api/user")]
		public async Task<IActionResult> GetUserById()
		{
			Response.Headers.Add("Access-Control-Allow-Origin", "*");
			var userId = _usersService.GetCurrentUserId().Result;
			var targetUser = await _usersService.GetUserByIdAsync(userId);
			if (targetUser == null)
			{
				return NotFound();
			}
			return Ok(targetUser);
		}

		[HttpGet]
		[Route("api/users")]
		public async Task<IEnumerable<User>> GetAllUsers()
		{
			return await _usersService.GetUserAsync();
		}

		[HttpGet]
		[Route("api/user/getName/{userId}")]
		public async Task<IActionResult> GetUserDataByUserId([FromRoute] string? userId)
		{
			if (userId == null)
			{
				return BadRequest("UserId must be not null!");
			}

			var userInfo = await _usersService.GetUserDataByUserId(userId);

			return userInfo == null ? BadRequest("User not found!") : Ok(userInfo);
		}

	}
}
