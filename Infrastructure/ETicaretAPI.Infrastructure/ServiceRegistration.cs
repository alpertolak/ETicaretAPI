using ETicaretAPI.Application.Absractions.Storage;
using ETicaretAPI.Application.Absractions.Storage.Local;
using ETicaretAPI.Application.Absractions.Token;
using ETicaretAPI.Infrastructure.Enums;
using ETicaretAPI.Infrastructure.Services.Storage;
using ETicaretAPI.Infrastructure.Services.Storage.Azure;
using ETicaretAPI.Infrastructure.Services.Storage.Local;
using ETicaretAPI.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Services
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollenction)
        {
            serviceCollenction.AddScoped<ITokenHandler, TokenHandler>();
            serviceCollenction.AddScoped<IStorageService, StorageService>();
        }

        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Stroage, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }

        public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
        {

            switch (storageType)    
            {
                case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, LoacalStorage>();
                    break;
                case StorageType.Azure:
                    serviceCollection.AddScoped<IStorage, AzureStorage>();
                    break;
                default:
                    serviceCollection.AddScoped<IStorage, LoacalStorage>();
                    break; 
            }


        }
        
    }
}
