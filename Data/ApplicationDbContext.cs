using Microsoft.EntityFrameworkCore;
using Elpis.Data.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.Identity;
using Elpis.Data.EntityConfigurations;


namespace Elpis.Data
{
	public class ApplicationDbContext : ApiAuthorizationDbContext<User>
	{
		public DbSet<TypeOfMenu> TypeOfMenus => Set<TypeOfMenu>();
		public DbSet<MenuItem> MenuItems => Set<MenuItem>();
		public DbSet<Menu> Menus => Set<Menu>();

		public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
			: base(options, operationalStoreOptions)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<User>().ToTable("Users");
			builder.Entity<IdentityRole>().ToTable(name: "Roles");
			builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
			builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
			builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
			builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
			builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

			builder.ApplyConfiguration(new TypeOfMenuEntityConfiguration());
			builder.ApplyConfiguration(new MenuItemEntityConfiguration());
			builder.ApplyConfiguration(new MenuEntityConfiguration());
			builder.ApplyConfiguration(new UserEntityConfiguration());
		}
	}
}