using Elpis.Business.Services.Interfaces;
using Elpis.Data.Models;
using Elpis.Data.Repositories.Interfaces;

namespace Elpis.Business.Services
{
	public class MenusService : IMenusService
	{
		private readonly IMenusRepository _menusRepository;
		public MenusService(IMenusRepository menusRepository)
		{
			_menusRepository = menusRepository;
		}

		public async Task<Menu> CreateMenu(Menu menu)
		{
			return await _menusRepository.AddAsync(menu);
		}

		public async Task<IEnumerable<Menu>> GetAllMenus(int typeOfMenuId)
		{
			return await _menusRepository.GetAllMenusAsync(typeOfMenuId);
		}

		public async Task<IEnumerable<Menu>> GetMenusAsync() => await _menusRepository.GetAllMenus();
		public Task<Menu?> GetMenuById(int id)
		{
			return _menusRepository.FindMenu(id);
		}
		public Task DeleteAsync(Menu menu)
		{
			return _menusRepository.DeleteAsync(menu);
		}
		public async Task<Menu?> GetMenuByIdAsync(int id) => await _menusRepository.FindAsync(id);
		public async Task UpdateMenuAsync(Menu menu) => await _menusRepository.UpdateAsync(menu);
	}
}
