using DigitalAvenue.Logic.LocationLogic;
using DigitalAvenue.Logic.ProductsLogic;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DigitalAvenue.Logic
{
    public static class Extension
    {
        public static IServiceCollection AppServiceCollections(this IServiceCollection services)
        {
            services.AddTransient<IProductsAppService, ProductsAppService>();
            services.AddTransient<ILocationAppService, LocationAppService>();
            services.AddTransient<IErrorServiceHandler, ErrorServiceHandler>();
            return services;
        }
    }
}
