using Elpis.Data.Models;

namespace Elpis.Models
{
	public class MenuItemRequestModel
	{
		public string Value { get; set; }
		public double Price { get; set; }
		public double Amount { get; set; }
		public string Information { get; set; }
		public int MenuId { get; set; }

		public MenuItem MenuItems(Menu menu)
		{
			return new MenuItem()
			{
				Value = Value,
				Price = Price,
				Amount = Amount,
				Information = Information,
				MenuId = menu.Id,
				Menu = menu
			};
		}
	}
}
