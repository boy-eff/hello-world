using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Word> Words => Set<Word>();
        public DbSet<WordCollection> WordCollections => Set<WordCollection>();
        public DbSet<WordDictionary> WordDictionaries => Set<WordDictionary>();

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Word>()
                .HasOne(w => w.WordCollection)
                .WithMany(wc => wc.Words)
                .HasForeignKey(w => w.WordCollectionId);

            builder.Entity<WordDictionary>()
                .HasMany(wd => wd.Words)
                .WithMany(w => w.WordDictionaries)
                .UsingEntity(join => join.ToTable("WordToWordCollection(Map)"));

            builder.Entity<User>()
                .HasOne(u => u.WordDictionary)
                .WithOne(d => d.Owner)
                .HasForeignKey<WordDictionary>(d => d.OwnerId);

            builder.Entity<WordCollection>()
                .HasOne(wc => wc.Owner)
                .WithMany(u => u.WordCollections)
                .HasForeignKey(wc => wc.OwnerId);
        }
    }
}