using Microsoft.AspNetCore.Identity;

namespace HelloWorld.Domain.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUserToRole> UserRoles { get; set; }
    }
}