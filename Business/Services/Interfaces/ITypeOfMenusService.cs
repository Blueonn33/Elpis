using Elpis.Data.Models;

namespace Elpis.Business.Services.Interfaces
{
	public interface ITypeOfMenusService
	{
		Task<IEnumerable<TypeOfMenu>> GetTypeOfMenusAsync();
		Task<IEnumerable<TypeOfMenu>> GetTypeOfMenusByUserId(string? id);
		Task<TypeOfMenu?> GetTypeOfMenuById(int id);
		Task<TypeOfMenu> UpdateTypeOfMenuName(TypeOfMenu TypeOfMenu);
		Task<TypeOfMenu> CreateTypeOfMenu(TypeOfMenu TypeOfMenu);
		Task<TypeOfMenu?> GetTypeOfMenuByNameAsync(string name);
		Task AddTypeOfMenuAsync(TypeOfMenu TypeOfMenu);
		Task<TypeOfMenu?> GetTypeOfMenuByIdAsync(int id);
		Task UpdateTypeOfMenuAsync(TypeOfMenu TypeOfMenu);
		Task DeleteAsync(TypeOfMenu TypeOfMenu);
	}
}
