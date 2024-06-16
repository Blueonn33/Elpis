using Elpis.Data.Repositories.Interfaces;
using Elpis.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elpis.Data.Repositories.Interfaces
{
	public interface ITypeOfMenusRepository : IRepository<TypeOfMenu>
	{
		Task<IEnumerable<TypeOfMenu>> GetTypeOfMenusByUserId(string? id);
		Task<int> GetCountAsync();
		Task<IEnumerable<TypeOfMenu>> GetAllTypeOfMenus();
		Task<TypeOfMenu?> GetTypeOfMenuByName(string name);
		Task<TypeOfMenu?> FindTypeOfMenu(int id);
	}
}