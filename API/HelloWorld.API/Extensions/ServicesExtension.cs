using HelloWorld.API.Services;
using HelloWorld.Application.Interfaces;
using HelloWorld.Infrastructure.Repositories;

namespace HelloWorld.API.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPhotoService, PhotoService>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICollectionRepository, CollectionRepository>();
            services.AddScoped<ICollectionThemeRepository, CollectionThemeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWordRepository, WordRepository>();
            return services;
        }
    }
}