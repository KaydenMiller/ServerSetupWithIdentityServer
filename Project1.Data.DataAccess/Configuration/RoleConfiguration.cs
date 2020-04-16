using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project1.Shared.Data.Identity;
using Project1.Shared.Data.Identity.Entities;

namespace Project1.Data.DataAccess.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<ApplicationRoleEntity>
    {
        //TODO: Fill out required role data
        public const string ADMIN_ID = "<enter_guid_id_here>";
        public const string USER_ID = "<enter_guid_id_here>";

        public void Configure(EntityTypeBuilder<ApplicationRoleEntity> builder)
        {
            builder.HasData(
                new ApplicationRoleEntity()
                {
                    Id = Guid.Parse(ADMIN_ID),
                    Name = UserRoleType.Administrator,
                    NormalizedName = UserRoleType.Administrator.ToUpper()
                },
                new ApplicationRoleEntity()
                {
                    Id = Guid.Parse(USER_ID),
                    Name = UserRoleType.User,
                    NormalizedName = UserRoleType.User.ToUpper()
                });
        }
    }
}