/*
 * @CreateTime: Sep 1, 2018 7:39 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 21, 2018 9:36 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Analisis.Interfaces;
using BionicInventory.Application.Analisis.Queries;
using BionicInventory.Application.CompanyProfile.Commands;
using BionicInventory.Application.CompanyProfile.Factories;
using BionicInventory.Application.CompanyProfile.Interfaces;
using BionicInventory.Application.CompanyProfile.Iterfaces;
using BionicInventory.Application.CompanyProfile.Queries;
using BionicInventory.Application.Customers.Commands;
using BionicInventory.Application.Customers.Factories;
using BionicInventory.Application.Customers.Interfaces;
using BionicInventory.Application.Customers.Interfaces.Query;
using BionicInventory.Application.Customers.Queries;
using BionicInventory.Application.Employees.Commands;
using BionicInventory.Application.Employees.Factories;
using BionicInventory.Application.Employees.Interfaces;
using BionicInventory.Application.Employees.Queries;
using BionicInventory.Application.FinishedProducts.Commands;
using BionicInventory.Application.FinishedProducts.Factories;
using BionicInventory.Application.FinishedProducts.Interfaces;
using BionicInventory.Application.FinishedProducts.Queries;
using BionicInventory.Application.Invoices.Commands;
using BionicInventory.Application.Invoices.Factories;
using BionicInventory.Application.Invoices.Interfaces;
using BionicInventory.Application.Invoices.InvoicePayment.Commands;
using BionicInventory.Application.Invoices.InvoicePayment.Factories;
using BionicInventory.Application.Invoices.InvoicePayment.Interfaces;
using BionicInventory.Application.Invoices.InvoicePayment.Queries;
using BionicInventory.Application.Invoices.Queries;
using BionicInventory.Application.ProductionOrders.Commands;
using BionicInventory.Application.ProductionOrders.Factories;
using BionicInventory.Application.ProductionOrders.Iterfaces;
using BionicInventory.Application.ProductionOrders.Queries;
using BionicInventory.Application.Products.Commands;
using BionicInventory.Application.Products.Commands.Booking;
using BionicInventory.Application.Products.Factories;
using BionicInventory.Application.Products.Factories.Booking;
using BionicInventory.Application.Products.Interfaces;
using BionicInventory.Application.Products.Interfaces.Booking;
using BionicInventory.Application.Products.Models;
using BionicInventory.Application.Products.Queries;
using BionicInventory.Application.Products.Queries.booking;
using BionicInventory.Application.SalesOrders.Commands;
using BionicInventory.Application.SalesOrders.Factory;
using BionicInventory.Application.SalesOrders.Interfaces;
using BionicInventory.Application.SalesOrders.Queries;
using BionicInventory.Application.SalesOrders.Queries.Report;
using BionicInventory.Application.Shipments.Commands;
using BionicInventory.Application.Shipments.Factories;
using BionicInventory.Application.Shipments.Interfaces;
using BionicInventory.Application.Shipments.Queries;
using BionicInventory.API.Commons;
using BionicInventory.API.Controllers.WorkOrders;
using BionicInventory.API.Controllers.WorkOrders.Interface;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NSwag.AspNetCore;

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
            services.AddScoped<IResponseFormatFactory, ResponseFromatFactory> ();
            services.AddScoped<IWorkOrdersFactory, WorkOrderFactory> ();
            services.AddScoped<IWorkOrdersQuery, WorkOrdersQuery> ();
            services.AddScoped<IWorkOrdersCommand, WorkOrdersCommand> ();
            services.AddScoped<IFinishedProductsFactories, FinishedProductsFactory> ();
            services.AddScoped<IFinishedProductsQuery, FinishedProductsQuery> ();
            services.AddScoped<IFinishedProductsCommand, FinishedProductsCommand> ();
            services.AddScoped<ISalesOrderFactory, SalesOrderFactory> ();
            services.AddScoped<ISalesOrderQuery, SalesOrderQuery> ();
            services.AddScoped<ISalesOrderReportQuery, SalesOrderReportQuery> ();
            services.AddScoped<ISalesOrderCommand, SalesOrderCommand> ();
            services.AddScoped<ICompanyProfileFactories, CompanyProfileFactories> ();
            services.AddScoped<ICompanyProfileQueries, CompanyProfileQueries> ();
            services.AddScoped<ICompanyProfileCommands, CompanyProfileCommands> ();
            services.AddScoped<IStockBookingQuery, StockBookingQuery> ();
            services.AddScoped<IStockBookingCommand, StockBookingCommand> ();
            services.AddScoped<IStockBookingFactory, StockBookingFactory> ();
            services.AddScoped<IInvoicesQuery, InvoicesQuery> ();
            services.AddScoped<IInvoicesCommand, InvoicesCommand> ();
            services.AddScoped<IInvoiceFactory, InvoiceFactory> ();
            services.AddScoped<IInvoicePaymentCommand, InvoicePaymentCommand> ();
            services.AddScoped<IInvoicePaymentFactory, InvoicePaymentFactory> ();
            services.AddScoped<IInvoicePaymentQuery, InvoicePaymentQuery> ();
            services.AddScoped<IWorkOrder, WorkOrdersController> ();
            services.AddScoped<IShipmentQuery, ShipmentQuery> ();
            services.AddScoped<IShipmentCommand, ShipmentCommand> ();
            services.AddScoped<IShipmentFactory, ShipmentFactory> ();
            services.AddScoped<IDashboardQuery, DashboardQuery> ();

            services.AddScoped<IInventoryDatabaseService, DatabaseService> ();

            services.AddSwaggerDocument ();

            services.AddCors (options => {
                options.AddPolicy ("AllowAllOrigins",
                    builder => builder.WithOrigins ("http://localhost:4200").AllowAnyMethod ().AllowAnyHeader ());
            });
            services.AddMvc (
                options => {
                    // Self referencing loop detected for property entity framework solution
                    options.OutputFormatters.Clear ();
                    options.OutputFormatters.Add (new JsonOutputFormatter (new JsonSerializerSettings () {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    }, ArrayPool<char>.Shared));
                }
            ).AddJsonOptions (options => options.SerializerSettings.ContractResolver = new DefaultContractResolver ());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) {

            loggerFactory.AddConsole ();

            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
                app.UseDatabaseErrorPage ();
            }
            app.UseCors ("AllowAllOrigins");

            app.UseMvc ();
            app.UseSwagger ();
            app.UseSwaggerUi3 (settings => {
                settings.ServerUrl = "/swagger/v1/swagger.json";
            });

        }
    }
}