using Application.Storage;
using Application.Storage.Azure;
using Application.Storage.Local;
using Application.TokenService;
using Infrastructure.Services;
using Infrastructure.Services.Storage;
using Infrastructure.Services.Storage.Azure;
using Infrastructure.Services.Storage.Local;
using Infrastructure.Services.TokenService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices( this IServiceCollection services)
        {
            services.AddScoped<IStorageService, StorageService>();
            services.AddScoped<ITokenHandler, TokenHandler>();
        }
        public static void AddStorage<T>(this IServiceCollection services) where T : class,IStorage
        {
            services.AddScoped<IStorage,T>();
        }
        
    }
}
