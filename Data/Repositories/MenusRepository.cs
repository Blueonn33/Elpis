using Elpis.Data.Models;
using Elpis.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Elpis.Data.Repositories
{
	public class MenusRepository : Repository<Menu>, IMenusRepository
	{
		public MenusRepository(ApplicationDbContext context) : base(context)
		{
		}

		public async Task<IEnumerable<Menu>> GetAllMenusAsync(int typeOfMenuId)
		{
			return await Entities.AsNoTracking().Include(t => t.TypeOfMenu.User)
				.Where(t => t.TypeOfMenuId == typeOfMenuId)
				.OrderBy(t => t.Id).ToListAsync();
		}
		public async Task<IEnumerable<Menu>> GetAllMenus() => await Entities.ToListAsync();

		public async Task<Menu?> FindMenu(int id)
		{
			return await Entities.Include(t => t.TypeOfMenu).FirstOrDefaultAsync(t => t.Id == id);
		}
	}
}
