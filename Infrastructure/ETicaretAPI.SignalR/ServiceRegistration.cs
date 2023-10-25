using ETicaretAPI.Application.Absractions.Hubs;
using ETicaretAPI.SignalR.HubServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.SignalR
{
    public static class ServiceRegistration
    {
        public static void AddSignalRService(this IServiceCollection collection)
        {
            collection.AddTransient<IProductHubService, ProductHubService>();
            collection.AddSignalR();
        }
    }
}
