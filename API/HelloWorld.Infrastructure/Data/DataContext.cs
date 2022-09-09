using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using HelloWorld.Domain.Entities;

namespace HelloWorld.Infrastructure.Data
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int, IdentityUserClaim<int>, 
                    AppUserToRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        private readonly IConfiguration _configuration;
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<Word> Words => Set<Word>();
        public DbSet<WordCollection> WordCollections => Set<WordCollection>();
        public DbSet<WordDictionary> WordDictionaries => Set<WordDictionary>();
        public DbSet<WordCollectionTheme> WordCollectionThemes => Set<WordCollectionTheme>();
        public DbSet<Photo> Photos => Set<Photo>();

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}