using Elpis.Data.Models;
using Elpis.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Elpis.Data.Repositories
{
	public class TypeOfMenusRepository : Repository<TypeOfMenu>, ITypeOfMenusRepository
	{
		public TypeOfMenusRepository(ApplicationDbContext context) : base(context)
		{
		}
		public async Task<IEnumerable<TypeOfMenu>> GetTypeOfMenusByUserId(string? Id)
		{
			return await Entities.Include(t => t.User).Where(t => t.UserId == Id).ToListAsync();
		}

		public async Task<TypeOfMenu?> FindTypeOfMenu(int id)
		{
			return await Entities.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == id);
		}

		public async Task<IEnumerable<TypeOfMenu>> GetAllTypeOfMenus() => await Entities.ToListAsync();

		public async Task<int> GetCountAsync() => await Entities.CountAsync();

		public async Task<TypeOfMenu?> GetTypeOfMenuByName(string name)
		{
			return await Entities.FirstOrDefaultAsync(t => t.Name == name);
		}
	}
}
