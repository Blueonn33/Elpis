using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Elpis.Data.Models;

namespace Elpis.Data.EntityConfigurations
{
	public class MenuItemEntityConfiguration : IEntityTypeConfiguration<MenuItem>
	{
		public void Configure(EntityTypeBuilder<MenuItem> builder)
		{
			builder.ToTable("MenuItems");

			builder.HasKey(mi => mi.Id);
			builder.Property(mi => mi.Value).HasMaxLength(255);
			builder.Property(mi => mi.Price).HasMaxLength(255);
			builder.Property(mi => mi.Amount).HasMaxLength(255);
			builder.Property(mi => mi.Information).HasMaxLength(255);

			builder.HasOne(m => m.Menu)
				.WithMany(mi => mi.MenuItems)
				.HasForeignKey(mi => mi.MenuId);
		}
	}
}
