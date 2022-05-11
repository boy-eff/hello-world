using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HelloWorld.API.Extensions
{
    public static class MigrationsExtension
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<DataContext>();

            dbContext.Database.Migrate();

            dbContext.WordCollectionThemes.Add(new Domain.Entities.WordCollectionTheme{Id = 0, Name = "Animals"});
            dbContext.SaveChanges();
        }
    }
}