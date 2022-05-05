using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.API.Interfaces;
using HelloWorld.API.Services;
using HelloWorld.Infrastructure.Interfaces;
using HelloWorld.Infrastructure.Repositories;

namespace HelloWorld.API.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICollectionService, CollectionService>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICollectionRepository, CollectionRepository>();
            services.AddScoped<ICollectionThemeRepository, CollectionThemeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}