using Elpis.Data.Models;

namespace Elpis.Data.Repositories.Interfaces
{
	public interface IMenuItemsRepository : IRepository<MenuItem>
	{
		Task<IEnumerable<MenuItem>> GetAllItemsAsync(int menuId);
		Task<IEnumerable<MenuItem>> GetAllItems();
		Task<MenuItem?> FindMenuItem(int id);
	}
}
