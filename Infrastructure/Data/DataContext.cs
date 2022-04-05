using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            Database.EnsureCreated();
            Users.Add(new User("Tom", "password"));
        }

        public DbSet<User> Users => Set<User>();

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql("Host=localhost;Port=5432;Database=helloworld;User Id=postgres;Password=password;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<WordCollection>()
                .HasMany(wc => wc.Words)
                .WithOne(w => w.WordCollection);

            builder.Entity<WordDictionary>()
                .HasMany(wd => wd.Words)
                .WithMany(w => w.Dictionaries);

            builder.Entity<User>()
                .HasOne(u => u.WordDictionary)
                .WithOne(d => d.Owner)
                .HasForeignKey<WordDictionary>(d => d.OwnerId);

            builder.Entity<User>()
                .HasMany(u => u.WordCollections)
                .WithOne(wc => wc.Owner)
                .HasForeignKey(wc => wc.OwnerId);
        }
    }
}