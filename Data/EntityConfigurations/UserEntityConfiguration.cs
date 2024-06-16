using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Elpis.Data.EntityConfigurations
{
	public class UserEntityConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("Users");

			builder.HasKey(u => u.Id);
			builder.Property(u => u.Name).HasMaxLength(255);

			builder.HasMany(u => u.TypeOfMenus)
				 .WithOne(tm => tm.User)
				 .HasForeignKey(tm => tm.UserId);
		}
	}
}
