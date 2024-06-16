using Elpis.Data.Models;

namespace Elpis.Models
{
	public class TypeOfMenuRequestModel
	{
		public string Name { get; set; }

		public TypeOfMenu ToCreateTypeOfMenu(string userId)
		{
			return new TypeOfMenu()
			{
				Name = Name,
				UserId = userId,
			};
		}
	}
}
