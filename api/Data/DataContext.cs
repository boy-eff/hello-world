using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Collection>? Collections { get; set; }
        public DbSet<Dictionary>? Dictionary { get; set; }
        public DbSet<Word>? Words { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
        }
    }
}