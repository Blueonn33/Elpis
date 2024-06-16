using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elpis.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Elpis.Data
{
	public class User : IdentityUser
	{
		public User()
		{
			Name = string.Empty;
			TypeOfMenus = new List<TypeOfMenu>();
		}

		public User(string name) : this()
		{
			Name = name ?? throw new ArgumentNullException(nameof(name));
		}

		public string Name { get; set; } = null!;
		public ICollection<TypeOfMenu> TypeOfMenus { get; set; } = null!;
	}
}