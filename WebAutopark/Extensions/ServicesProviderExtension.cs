using Microsoft.Extensions.DependencyInjection;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.BusinessLogic.Services;
using WebAutopark.Core.Entities;
using WebAutopark.Core.Interfaces;
using WebAutopark.DatabaseAccess.Repositories;

namespace WebAutopark.Extensions
{
    public static class ServicesProviderExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Component>, ComponentRepository>();
            services.AddScoped<IRepository<Vehicle>, VehicleRepository>();
            services.AddScoped<IRepository<VehicleType>, VehicleTypeRepository>();
            services.AddScoped<IRepository<Order>, OrderRepository>();
            services.AddScoped<IRepository<OrderItem>, OrderItemRepository>();
            return services;
        }

        public static IServiceCollection AddDtoServices(this IServiceCollection services)
        {
            services.AddScoped<IDataService<VehicleDto>, VehicleService>();
            services.AddScoped<IDataService<VehicleTypeDto>, VehicleTypeService>();
            return services;
        }
    }
}
