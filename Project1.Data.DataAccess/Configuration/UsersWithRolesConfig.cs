using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project1.Data.DataAccess.Configuration
{
    public class UsersWithRolesConfig : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            var iur = new IdentityUserRole<Guid>()
            {
                RoleId = Guid.Parse(RoleConfiguration.ADMIN_ID),
                UserId = Guid.Parse(AdminConfiguration.ADMIN_USER_ID)
            };

            builder.HasData(iur);
        }
    }
}