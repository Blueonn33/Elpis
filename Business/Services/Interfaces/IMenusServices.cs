using Elpis.Data.Models;

namespace Elpis.Business.Services.Interfaces
{
	public interface IMenusService
	{
		Task<IEnumerable<Menu>> GetAllMenus(int typeOfMenuId);
		Task<Menu> CreateMenu(Menu menu);
		Task<IEnumerable<Menu>> GetMenusAsync();
		Task<Menu?> GetMenuById(int id);
		Task DeleteAsync(Menu menu);
		Task<Menu?> GetMenuByIdAsync(int id);
		Task UpdateMenuAsync(Menu menu);
	}
}
