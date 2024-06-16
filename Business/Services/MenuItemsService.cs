using Elpis.Business.Services.Interfaces;
using Elpis.Data.Models;
using Elpis.Data.Repositories.Interfaces;

namespace Elpis.Business.Services
{
	public class MenuItemsService : IMenuItemsService
	{
		private readonly IMenuItemsRepository _menuItemsRepository;
		public MenuItemsService(IMenuItemsRepository menuItemsRepository)
		{
			_menuItemsRepository = menuItemsRepository;
		}

		public async Task<MenuItem> CreateMenuItem(MenuItem menuItem)
		{
			return await _menuItemsRepository.AddAsync(menuItem);
		}

		public async Task<IEnumerable<MenuItem>> GetAllItems(int menuId)
		{
			return await _menuItemsRepository.GetAllItemsAsync(menuId);
		}

		public async Task<IEnumerable<MenuItem>> GetMenuItemsAsync() => await _menuItemsRepository.GetAllItems();
		public Task<MenuItem?> GetMenuItemById(int id)
		{
			return _menuItemsRepository.FindMenuItem(id);
		}
		public Task DeleteAsync(MenuItem menuItem)
		{
			return _menuItemsRepository.DeleteAsync(menuItem);
		}
		public async Task<MenuItem?> GetMenuItemByIdAsync(int id) => await _menuItemsRepository.FindAsync(id);
		public async Task UpdateMenuItemAsync(MenuItem menuItem) => await _menuItemsRepository.UpdateAsync(menuItem);
	}
}
