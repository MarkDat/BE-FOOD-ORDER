using FoodOrder.Application.ViewModels;
using FoodOrder.Application.ViewModels.AppSetting;
using FoodOrder.Entity.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using FoodOrder.Application.Services;
using FoodOrder.Application.Services.Interfaces;
using FoodOrder.Infrastructure;
using FoodOrder.Infrastructure.SeedWorks;
using System;

namespace FoodOrder.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            _configuration.GetSection("Configurations").Get<AppSettings>(option =>
            {
                option.BindNonPublicProperties = true;
            });
        }

        private IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "FoodOrder", Version = "v1"});
            });

            // Add db context
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(AppSettings.ConnectionString));
            services.AddScoped<Func<FoodOrderContext>>((provider) => () => provider.GetService<FoodOrderContext>());

            services
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IBasketService, BasketService>()
                .AddScoped<IOrderService, OrderService>()
                .AddScoped<IProductService, ProductService>()
                .AddScoped<IInvoiceService, InvoiceService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.RoutePrefix = string.Empty;
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "FoodOrder v1");
                });
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}