using DigitalAvenue.Repository.LocationsRepo;
using DigitalAvenue.Repository.ProductsRepo;
using DigitalAvenue.Repository.StorageUtil;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DigitalAvenue.Repository
{
    public static class Extension
    {

        public static IServiceCollection RepoServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IStorage, Storage>();
            services.AddTransient<IProductRepo, ProductRepo>();
            services.AddTransient<ILocationRepo, LocationRepo>();
            services.AddTransient<ILocationRepo, LocationRepo>();
            return services;
        }
    }
}
