using Microsoft.Extensions.DependencyInjection;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.BusinessLogic.Services;
using WebAutopark.BusinessLogic.Services.Interfaces;
using WebAutopark.Core.Entities;
using WebAutopark.Core.Interfaces;
using WebAutopark.Core.Interfaces.Repositories;
using WebAutopark.DatabaseAccess.Repositories;

namespace WebAutopark.Extensions
{
    public static class ServicesProviderExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Component>, ComponentRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IRepository<VehicleType>, VehicleTypeRepository>();
            services.AddScoped<IRepository<Order>, OrderRepository>();
            services.AddScoped<IRepository<OrderItem>, OrderItemRepository>();
            return services;
        }

        public static IServiceCollection AddDtoServices(this IServiceCollection services)
        {
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IDataService<VehicleTypeDto>, VehicleTypeService>();
            services.AddScoped<IDataService<OrderDto>, OrderService>();
            services.AddScoped<IDataService<OrderItemDto>, OrderItemService>();
            services.AddScoped<IDataService<ComponentDto>, ComponentService>();
            return services;
        }
    }
}
