using Microsoft.AspNetCore.Identity;
using System;

namespace Angular7NetCoreStore.Infra.CrossCutting.Identity.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base()
        {
            
        }

        public Guid CustomerId { get; set; }
    }
}
