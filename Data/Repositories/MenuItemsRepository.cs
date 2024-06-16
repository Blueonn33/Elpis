using Elpis.Data.Models;
using Elpis.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Elpis.Data.Repositories
{
	public class MenuItemsRepository : Repository<MenuItem>, IMenuItemsRepository
	{
		public MenuItemsRepository(ApplicationDbContext context) : base(context)
		{
		}

		public async Task<IEnumerable<MenuItem>> GetAllItemsAsync(int menuId)
		{
			return await Entities.AsNoTracking().Include(t => t.Menu.TypeOfMenu)
				.Where(t => t.MenuId == menuId)
				.OrderByDescending(t => t.Id).ToListAsync();
		}
		public async Task<IEnumerable<MenuItem>> GetAllItems() => await Entities.ToListAsync();

		public async Task<MenuItem?> FindMenuItem(int id)
		{
			return await Entities.Include(t => t.Menu).FirstOrDefaultAsync(t => t.Id == id);
		}
	}
}
