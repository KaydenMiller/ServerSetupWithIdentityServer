using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project1.Data.DataAccess.Extensions.DataContextExtensions;
using Project1.Shared.Data.Identity.Entities;

namespace Project1.Data.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUserEntity, ApplicationRoleEntity, Guid>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            this.SeedApplicationDataContext(builder);
        }
    }
}