using System.ComponentModel.DataAnnotations;

namespace Elpis.Data.Models
{
	public class MenuItem
	{
		public MenuItem()
		{
			Value = string.Empty;
			Price = 0;
			Amount = 0;
			Information = string.Empty;
		}

		public MenuItem(Menu? menu, string value, double price, double amount, string information) : this()
		{
			_menu = menu;
			Value = value ?? throw new ArgumentNullException(nameof(value));
			Price = price;
			Amount = amount;
			Information = information;
		}
		public int Id { get; set; }
		public int MenuId { get; set; }
		public Menu? _menu;
		public Menu Menu;
		public string Value { get; set; }
		public double Price { get; set; }
		public double Amount { get; set; }
		public string Information { get; set; }
	}
}
