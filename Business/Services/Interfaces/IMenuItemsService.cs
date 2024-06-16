using Elpis.Data.Models;

namespace Elpis.Business.Services.Interfaces
{
	public interface IMenuItemsService
	{
		Task<IEnumerable<MenuItem>> GetAllItems(int menuId);
		Task<MenuItem> CreateMenuItem(MenuItem menuItem);
		Task<IEnumerable<MenuItem>> GetMenuItemsAsync();
		Task<MenuItem?> GetMenuItemById(int id);
		Task DeleteAsync(MenuItem menuItem);
		Task<MenuItem?> GetMenuItemByIdAsync(int id);
		Task UpdateMenuItemAsync(MenuItem menuItem);
	}
}
