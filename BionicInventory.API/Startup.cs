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
using BionicInventory.DataStore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BionicInventory.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => {
                options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            });
            services.AddScoped<ICustomersQuery, CustomersQuery>();
            services.AddScoped<ICustomersCommand, CustomersCommand>();
            services.AddScoped<ICustomersFactory, CustomerFactories>();
            services.AddScoped<IEmployeesQuery, EmployeesQuery>();
            services.AddScoped<IEmployeesCommand, EmployeesCommand>();
            services.AddScoped<IEmployeesFactory, EmployeesFactory>();
            services.AddScoped<IInventoryDatabaseService, DatabaseService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseMvc();
        }
    }
}
