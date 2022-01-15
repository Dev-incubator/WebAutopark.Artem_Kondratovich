using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.BusinessLogic.Services;
using WebAutopark.Core.Entities;
using WebAutopark.Core.Interfaces;
using WebAutopark.DatabaseAccess;
using WebAutopark.DatabaseAccess.Repositories;
using WebAutopark.Mappings;

namespace WebAutopark
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSingleton<IConnectionStringProvider, ConnectionStringProvider>();
            services.AddScoped<IRepository<Component>, ComponentRepository>();
            services.AddScoped<IRepository<Vehicle>, VehicleRepository>();
            services.AddScoped<IRepository<VehicleType>, VehicleTypeRepository>();
            services.AddScoped<IRepository<Order>, OrderRepository>();
            services.AddScoped<IRepository<OrderItem>, OrderItemRepository>();

            services.AddScoped<IDtoService<VehicleDto>, VehicleService>();
            services.AddScoped<IDtoService<VehicleTypeDto>, VehicleTypeService>();

            services.AddAutoMapper(typeof(DtoEntityProfile), typeof(ViewModelDtoProfile));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
                             {
                                 endpoints.MapDefaultControllerRoute();
                             });
        }
    }
}