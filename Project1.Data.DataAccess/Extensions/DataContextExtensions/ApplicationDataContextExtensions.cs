using Microsoft.EntityFrameworkCore;
using Project1.Data.DataAccess.Configuration;
using Project1.Data.DataAccess.Data;

namespace Project1.Data.DataAccess.Extensions.DataContextExtensions
{
    public static class ApplicationDataContextExtensions
    {
        public static void SeedApplicationDataContext(this ApplicationDbContext context, ModelBuilder builder)
        {
            context.SeedAspNetRoles(builder);
        }

        public static void SeedAspNetRoles(this ApplicationDbContext context, ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new AdminConfiguration());
            builder.ApplyConfiguration(new UsersWithRolesConfig());
        }
    }
}