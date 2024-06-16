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
	public class MenuItemController : ControllerBase
	{
		private readonly IMenuItemsService _menuItemsService;
		private readonly IMenusService _menusService;
		public MenuItemController(IMenuItemsService menuItemsService, IMenusService menusService)
		{
			_menuItemsService = menuItemsService;
			_menusService = menusService;
		}

		[HttpGet]
		[Route("api/menuItems")]
		public async Task<IEnumerable<MenuItem>> GetAllItems()
		{
			Response.Headers.Add("Access-Control-Allow-Origin", "*");
			return await _menuItemsService.GetMenuItemsAsync();
		}

		[HttpGet]
		[Route("api/menuItems/{menuId}")]
		public async Task<IActionResult> GetAllItems([FromRoute] int menuId)
		{
			Response.Headers.Add("Access-Control-Allow-Origin", "*");
			var items = await _menuItemsService.GetAllItems(menuId);

			if (!items.Any())
			{
				return BadRequest("No existing items!");
			}
			return Ok(items);
		}

		[HttpGet]
		[Route("api/menuItem/{id}")]
		public async Task<IActionResult> GetMenuItemById([FromRoute] int id)
		{
			var targetMenuItem = await _menuItemsService.GetMenuItemByIdAsync(id);
			if (targetMenuItem == null)
			{
				return NotFound();
			}
			return Ok(targetMenuItem);
		}

		[HttpPost]
		[Route("api/create/menuItem/{menuId}")]
		public async Task<IActionResult> CreateMenuItems([FromRoute] int menuId, [FromBody] MenuItemRequestModel menuItemsRequestModel)
		{
			var menu = await _menusService.GetMenuById(menuId);
			var menuItem = menuItemsRequestModel.MenuItems(menu);

			var result = await _menuItemsService.CreateMenuItem(menuItem);

			return Ok(result);
		}

		[HttpDelete]
		[Route("api/delete/menuItem/{Id}")]
		public async Task<IActionResult> DeleteMenuItem([FromRoute] int id)
		{
			var targetItem = await _menuItemsService.GetMenuItemById(id);
			if (targetItem == null)
			{
				return NotFound("Item doesn't exist");
			}
			await _menuItemsService.DeleteAsync(targetItem);

			return Ok(targetItem);
		}
	}
}
