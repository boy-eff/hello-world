using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Users;
using Domain.Entities.Words;   
using Domain.Entities.WordCollections;
using Domain.Entities.WordDictionaries;

namespace Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<WordCollection> Collections => Set<WordCollection>();
        public DbSet<WordDictionary> Dictionary => Set<WordDictionary>();
        public DbSet<Word> Words => Set<Word>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
        }
    }
}