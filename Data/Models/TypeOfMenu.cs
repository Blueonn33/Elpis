using Elpis.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Elpis.Data.Models
{
	public class TypeOfMenu
	{
		public TypeOfMenu()
		{
			Name = string.Empty;
			Menus = new List<Menu>();
		}
		public TypeOfMenu(User? user, string name) : this()
		{
			_user = user;
			Name = name ?? throw new ArgumentNullException(nameof(name));
		}
		public int Id { get; set; }

		public string Name { get; set; }
		public User? _user;
		public string? UserId { get; set; }
		public User User;
		public ICollection<Menu> Menus { get; set; }
	}
}