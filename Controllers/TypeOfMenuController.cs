using Elpis.Business.Services.Interfaces;
using Elpis.Data;
using Elpis.Data.Models;
using Elpis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Elpis.Controllers
{
	[ApiController]
	[Authorize]
	public class TypeOfMenuController : ControllerBase
	{
		private readonly ITypeOfMenusService _TypeOfMenusService;
		private readonly IUsersService _usersService;
		private readonly UserManager<User> _userManager;

		public TypeOfMenuController(ITypeOfMenusService TypeOfMenusService, IUsersService usersService,
			UserManager<User> userManager)
		{
			_TypeOfMenusService = TypeOfMenusService;
			_usersService = usersService;
			_userManager = userManager;
		}

		[HttpGet]
		[Route("api/typeOfMenus")]
		public async Task<IActionResult> GetAllTypeOfMenus()
		{
			var userId = _usersService.GetCurrentUserId().Result;
			var TypeOfMenus = await _TypeOfMenusService.GetTypeOfMenusByUserId(userId);

			if (!TypeOfMenus.Any())
			{
				return BadRequest("No existing types!");
			}
			return Ok(TypeOfMenus);
		}

		[HttpGet]
		[Route("api/typeOfMenu/{id}")]
		public async Task<IActionResult> GetTypeOfMenuById([FromRoute] int id)
		{
			var targetTypeOfMenu = await _TypeOfMenusService.GetTypeOfMenuByIdAsync(id);
			if (targetTypeOfMenu == null)
			{
				return NotFound();
			}
			return Ok(targetTypeOfMenu);
		}

		[HttpPost]
		[Route("api/create/typeOfMenu")]
		public async Task<IActionResult> CreateTypeOfMenu([FromBody] TypeOfMenuRequestModel TypeOfMenuRequestModel)
		{
			var userId = _usersService.GetCurrentUserId().Result;
			var TypeOfMenu = TypeOfMenuRequestModel.ToCreateTypeOfMenu(userId);
			var result = await _TypeOfMenusService.CreateTypeOfMenu(TypeOfMenu);

			if (result == null)
			{
				return BadRequest("The type already exists");
			}
			else
			{
				return Ok(result);
			}

		}

		[HttpDelete]
		[Route("api/delete/typeOfMenu/{id}")]
		public async Task<IActionResult> DeleteTypeOfMenu([FromRoute] int id)
		{
			var targetTypeOfMenu = await _TypeOfMenusService.GetTypeOfMenuByIdAsync(id);
			if (targetTypeOfMenu == null)
			{
				return NotFound("Type doesn't exist");
			}
			await _TypeOfMenusService.DeleteAsync(targetTypeOfMenu);

			return Ok(targetTypeOfMenu);
		}

		[HttpPatch]
		[Route("api/edit/typeOfMenu/{id}")]
		public async Task<IActionResult> EditTypeOfMenuName([FromRoute] int id, [FromBody] TypeOfMenu TypeOfMenu)
		{
			var targetTypeOfMenu = await _TypeOfMenusService.GetTypeOfMenuByIdAsync(id);
			if (targetTypeOfMenu == null)
			{
				return NotFound();
			}

			if (targetTypeOfMenu.Name == null || targetTypeOfMenu.Name == string.Empty)
			{
				return BadRequest();
			}
			if (targetTypeOfMenu.Name == TypeOfMenu.Name)
			{
				return BadRequest();
			}

			targetTypeOfMenu.Name = TypeOfMenu.Name;
			await _TypeOfMenusService.UpdateTypeOfMenuAsync(targetTypeOfMenu);

			return Ok(targetTypeOfMenu);
		}
	}
}
