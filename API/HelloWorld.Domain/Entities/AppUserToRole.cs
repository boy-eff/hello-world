using Microsoft.AspNetCore.Identity;

namespace HelloWorld.Domain.Entities
{
    public class AppUserToRole : IdentityUserRole<int>
    {
        public AppUser User { get; set; }

        public AppRole Role { get; set; }
    }
}