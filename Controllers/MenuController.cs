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
	public class MenuController : ControllerBase
	{
		private readonly IMenusService _menusService;
		private readonly ITypeOfMenusService _typeOfMenusService;
		public MenuController(IMenusService menusService, ITypeOfMenusService typeOfMenusService)
		{
			_menusService = menusService;
			_typeOfMenusService = typeOfMenusService;
		}

		[HttpGet]
		[Route("api/menus/{typeOfMenuId}")]
		public async Task<IActionResult> GetAllMenus([FromRoute] int typeOfMenuId)
		{
			Response.Headers.Add("Access-Control-Allow-Origin", "*");
			var items = await _menusService.GetAllMenus(typeOfMenuId);

			if (!items.Any())
			{
				return BadRequest("No existing menus!");
			}
			return Ok(items);
		}

		[HttpGet]
		[Route("api/menu/{id}")]
		public async Task<IActionResult> GetMenuById([FromRoute] int id)
		{
			var targetMenu = await _menusService.GetMenuByIdAsync(id);
			if (targetMenu == null)
			{
				return NotFound();
			}
			return Ok(targetMenu);
		}

		[HttpPost]
		[Route("api/create/menu/{typeOfMenuId}")]
		public async Task<IActionResult> CreateMenus([FromRoute] int typeOfMenuId, [FromBody] MenuRequestModel menusRequestModel)
		{
			var typeOfMenu = await _typeOfMenusService.GetTypeOfMenuById(typeOfMenuId);
			var menu = menusRequestModel.Menus(typeOfMenu);

			var result = await _menusService.CreateMenu(menu);

			return Ok(result);
		}

		[HttpDelete]
		[Route("api/delete/menu/{Id}")]
		public async Task<IActionResult> DeleteMenu([FromRoute] int id)
		{
			var targetItem = await _menusService.GetMenuById(id);
			if (targetItem == null)
			{
				return NotFound("Menu doesn't exist");
			}
			await _menusService.DeleteAsync(targetItem);

			return Ok(targetItem);
		}
	}
}
