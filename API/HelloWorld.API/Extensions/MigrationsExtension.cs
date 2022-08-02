using HelloWorld.Domain.Entities;
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

            dbContext.WordCollectionThemes.Add(new WordCollectionTheme{Id = 0, Name = "Animals"});
            dbContext.SaveChanges();
        }
    }
}