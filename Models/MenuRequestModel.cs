using Elpis.Data.Models;

namespace Elpis.Models
{
	public class MenuRequestModel
	{
		public string Name { get; set; }
		public int TypeOfMenuId { get; set; }

		public Menu Menus(TypeOfMenu TypeOfMenu)
		{
			return new Menu()
			{
				Name = Name,
				TypeOfMenuId = TypeOfMenu.Id,
				TypeOfMenu = TypeOfMenu
			};
		}
	}
}
