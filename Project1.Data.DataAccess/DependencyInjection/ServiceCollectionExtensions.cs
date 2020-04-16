using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project1.Data.DataAccess.Data;
using Project1.Shared.Data.Identity.Entities;

namespace Project1.Data.DataAccess.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("<connection_string_name>")));

            services.AddTransient<DbContext, ApplicationDbContext>();

            services.AddIdentityCore<ApplicationUserEntity>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                })
                .AddRoles<ApplicationRoleEntity>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}