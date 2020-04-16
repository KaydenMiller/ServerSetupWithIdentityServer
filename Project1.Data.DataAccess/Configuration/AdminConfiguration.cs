using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project1.Shared.Data.Identity;
using Project1.Shared.Data.Identity.Entities;

namespace Project1.Data.DataAccess.Configuration
{
    
    public class AdminConfiguration : IEntityTypeConfiguration<ApplicationUserEntity>
    {
        //TODO: Fill out required role data
        public const string ADMIN_USER_ID = "<enter_guid_id_here>";

        public void Configure(EntityTypeBuilder<ApplicationUserEntity> builder)
        {
            var email = "user.name@gurutechnologies.net";

            var admin = new ApplicationUserEntity()
            {
                Id = Guid.Parse(ADMIN_USER_ID),
                UserName = "admin",
                NormalizedUserName = "admin".ToUpper(),
                FirstName = "Master",
                LastName = "Admin",
                Email = email,
                NormalizedEmail = email.ToUpper(),
                PhoneNumber = "(123) 456-7890",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            admin.PasswordHash = PassGenerate(admin);
            builder.HasData(admin);
        }

        private string PassGenerate(ApplicationUserEntity user)
        {
            var passHash = new PasswordHasher<ApplicationUserEntity>();
            return passHash.HashPassword(user, "Password1!");
        }
    }
}