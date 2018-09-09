/*
 * @CreateTime: Sep 1, 2018 7:39 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 9, 2018 6:48 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Customers.Commands;
using BionicInventory.Application.Customers.Factories;
using BionicInventory.Application.Customers.Interfaces;
using BionicInventory.Application.Customers.Interfaces.Query;
using BionicInventory.Application.Customers.Queries;
using BionicInventory.Application.Employees.Commands;
using BionicInventory.Application.Employees.Factories;
using BionicInventory.Application.Employees.Interfaces;
using BionicInventory.Application.Employees.Queries;
using BionicInventory.Application.Products.Commands;
using BionicInventory.Application.Products.Factories;
using BionicInventory.Application.Products.Interfaces;
using BionicInventory.Application.Products.Models;
using BionicInventory.Application.Products.Queries;
using BionicInventory.API.Commons;
using BionicInventory.DataStore;
using BionicInventory.Domain.Items;
using BionicInventory.Domain.Items.ItemPrices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;

namespace BionicInventory.API {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {

            services.AddScoped<ICustomersQuery, CustomersQuery> ();
            services.AddScoped<ICustomersCommand, CustomersCommand> ();
            services.AddScoped<ICustomersFactory, CustomerFactories> ();
            services.AddScoped<IProductsQuery, ProductsQuery> ();
            services.AddScoped<IProductsCommand, ProductsCommand> ();
            services.AddScoped<IProductsFactory, ProductsFactory> ();
            services.AddScoped<IEmployeesQuery, EmployeesQuery> ();
            services.AddScoped<IEmployeesCommand, EmployeesCommand> ();
            services.AddScoped<IEmployeesFactory, EmployeesFactory> ();
            services.AddScoped<IInventoryDatabaseService, DatabaseService> ();
            services.AddScoped<IResponseFormatFactory, ResponseFromatFactory> ();
            services.AddCors (options => {
                options.AddPolicy ("AllowAllOrigins",
                    builder => builder.WithOrigins ("http://localhost:4200").AllowAnyMethod ().AllowAnyHeader ());
            });
            services.AddMvc ().AddJsonOptions (options => options.SerializerSettings.ContractResolver = new DefaultContractResolver ());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
                app.UseDatabaseErrorPage ();
            }
            app.UseCors ("AllowAllOrigins");

            app.UseMvc ();

        }
    }
}