using Elpis.Business.Services.Interfaces;
using Elpis.Data.Models;
using Elpis.Data.Repositories.Interfaces;

namespace Elpis.Business.Services
{
	public class TypeOfMenusService : ITypeOfMenusService
	{
		private readonly ITypeOfMenusRepository _TypeOfMenusRepository;

		public TypeOfMenusService(ITypeOfMenusRepository TypeOfMenusRepository)
		{
			_TypeOfMenusRepository = TypeOfMenusRepository;
		}

		public Task<TypeOfMenu?> GetTypeOfMenuById(int id)
		{
			return _TypeOfMenusRepository.FindTypeOfMenu(id);
		}

		public async Task<IEnumerable<TypeOfMenu>> GetTypeOfMenusByUserId(string? id)
		{
			return await _TypeOfMenusRepository.GetTypeOfMenusByUserId(id);
		}

		public async Task<TypeOfMenu> UpdateTypeOfMenuName(TypeOfMenu TypeOfMenu)
		{
			var group = await _TypeOfMenusRepository.FindTypeOfMenu(TypeOfMenu.Id);

			if (group != null)
			{
				if (group.Name == TypeOfMenu.Name)
				{
					return null;
				}
				group.Name = TypeOfMenu.Name;
				await _TypeOfMenusRepository.UpdateAsync(group);
				return group;
			}
			return null;
		}

		public async Task<TypeOfMenu> CreateTypeOfMenu(TypeOfMenu TypeOfMenu)
		{
			var isExisting = await _TypeOfMenusRepository.GetTypeOfMenuByName(TypeOfMenu.Name);
			if (isExisting != null)
			{
				return null;
			}
			return await _TypeOfMenusRepository.AddAsync(TypeOfMenu);
		}


		public async Task AddTypeOfMenuAsync(TypeOfMenu TypeOfMenu) => await _TypeOfMenusRepository.AddAsync(TypeOfMenu);

		public async Task<TypeOfMenu?> GetTypeOfMenuByNameAsync(string name)
		{
			return await _TypeOfMenusRepository.GetTypeOfMenuByName(name);
		}

		public async Task<IEnumerable<TypeOfMenu>> GetTypeOfMenusAsync() => await _TypeOfMenusRepository.GetAllTypeOfMenus();

		public async Task<TypeOfMenu?> GetTypeOfMenuByIdAsync(int id) => await _TypeOfMenusRepository.FindAsync(id);

		public async Task UpdateTypeOfMenuAsync(TypeOfMenu TypeOfMenu) => await _TypeOfMenusRepository.UpdateAsync(TypeOfMenu);
		public Task DeleteAsync(TypeOfMenu TypeOfMenu)
		{
			return _TypeOfMenusRepository.DeleteAsync(TypeOfMenu);
		}
	}
}