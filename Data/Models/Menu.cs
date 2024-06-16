using Elpis.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Elpis.Data.Models
{
	public class Menu
	{
		public Menu()
		{
			Name = string.Empty;
			MenuItems = new List<MenuItem>();
		}

		public Menu(TypeOfMenu? typeOfMenu, string name) : this()
		{
			_typeOfMenu = typeOfMenu;
			Name = name ?? throw new ArgumentNullException(nameof(name));
		}
		public int Id { get; set; }
		public int TypeOfMenuId { get; set; }
		public TypeOfMenu? _typeOfMenu;
		public TypeOfMenu TypeOfMenu;
		public string Name { get; set; }
		public ICollection<MenuItem> MenuItems { get; set; }
	}
}
