using System;
using Microsoft.AspNetCore.Identity;

namespace Project1.Shared.Data.Identity.Entities
{
    public class ApplicationUserEntity : IdentityUser<Guid>, IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}