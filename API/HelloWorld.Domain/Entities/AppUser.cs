using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace HelloWorld.Domain.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public WordDictionary WordDictionary { get; set; }
        public ICollection<WordCollection> WordCollections { get; set; }
        public ICollection<AppUserToRole> UserRoles { get; set; }
        public Photo Photo { get; set; }
    }
}