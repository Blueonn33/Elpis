using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Elpis.Data.Models;

namespace Elpis.Data.EntityConfigurations
{
	public class MenuEntityConfiguration : IEntityTypeConfiguration<Menu>
	{
		public void Configure(EntityTypeBuilder<Menu> builder)
		{
			builder.ToTable("Menus");

			builder.HasKey(m => m.Id);
			builder.Property(m => m.Name).HasMaxLength(255);

			builder.HasOne(tm => tm.TypeOfMenu)
				.WithMany(m => m.Menus)
				.HasForeignKey(m => m.TypeOfMenuId);

			builder.HasMany(m => m.MenuItems)
				 .WithOne(mi => mi.Menu)
				 .HasForeignKey(mi => mi.MenuId);

		}
	}
}
