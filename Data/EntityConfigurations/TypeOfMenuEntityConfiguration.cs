using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Elpis.Data.Models;

namespace Elpis.Data.EntityConfigurations
{
	public class TypeOfMenuEntityConfiguration : IEntityTypeConfiguration<TypeOfMenu>
	{
		public void Configure(EntityTypeBuilder<TypeOfMenu> builder)
		{
			builder.ToTable("TypeOfMenus");

			builder.HasKey(tm => tm.Id);
			builder.Property(tm => tm.Name).HasMaxLength(255);

			builder.HasOne(tm => tm.User)
				.WithMany(u => u.TypeOfMenus)
				.HasForeignKey(u => u.UserId);

			builder.HasMany(tm => tm.Menus)
				 .WithOne(m => m.TypeOfMenu)
				 .HasForeignKey(m => m.TypeOfMenuId);

		}
	}
}
