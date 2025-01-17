using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.Core.Service;
using Otus.Teaching.PromoCodeFactory.DataAccess.Data;
using Otus.Teaching.PromoCodeFactory.DataAccess.Repositories;

namespace Otus.Teaching.PromoCodeFactory.WebHost
{
    public class Startup(IConfiguration configuration)
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            
            // services.AddScoped(typeof(IRepository<Employee>), (x) => 
            //     new InMemoryRepository<Employee>(FakeDataFactory.Employees));
            // services.AddScoped(typeof(IRepository<Role>), (x) => 
            //     new InMemoryRepository<Role>(FakeDataFactory.Roles));
            // services.AddScoped(typeof(IRepository<Preference>), (x) => 
            //     new InMemoryRepository<Preference>(FakeDataFactory.Preferences));
            // services.AddScoped(typeof(IRepository<Customer>), (x) => 
            //     new InMemoryRepository<Customer>(FakeDataFactory.Customers));
            
            services.AddDbContext<DataContext>(opt=>opt.UseSqlite(configuration.GetConnectionString(nameof(DataContext))));
            
            services.AddScoped(typeof(IRepository<Role>), (x) => new EfRepository<Role>(x.GetService<DataContext>()));
            services.AddScoped(typeof(IRepository<Employee>), (x) => new EfRepository<Employee>(x.GetService<DataContext>()));
            services.AddScoped(typeof(IRepository<Preference>), (x) => new EfRepository<Preference>(x.GetService<DataContext>()));
            services.AddScoped(typeof(IRepository<Customer>), (x) => new EfRepository<Customer>(x.GetService<DataContext>()));
            services.AddScoped(typeof(IRepository<PromoCode>), (x) =>new EfRepository<PromoCode>(x.GetService<DataContext>()));
            
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            // Регистрация сервиса
            services.AddScoped<CustomerService>();
            // Регистрация контроллеров
            services.AddControllers();
            

            

            services.AddOpenApiDocument(options =>
            {
                options.Title = "PromoCode Factory API Doc";
                options.Version = "1.0";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3(x =>
            {
                x.DocExpansion = "list";
            });
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}