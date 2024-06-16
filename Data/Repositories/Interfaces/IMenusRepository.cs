using Elpis.Data.Models;

namespace Elpis.Data.Repositories.Interfaces
{
	public interface IMenusRepository : IRepository<Menu>
	{
		Task<IEnumerable<Menu>> GetAllMenusAsync(int typeOfMenuId);
		Task<IEnumerable<Menu>> GetAllMenus();
		Task<Menu?> FindMenu(int id);
	}
}
