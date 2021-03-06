﻿/*
 * @CreateTime: Sep 1, 2018 7:39 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 21, 2019 11:56 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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
using BionicInventory.Application.Interfaces;
using BionicInventory.Application.Invoices.Commands;
using BionicInventory.Application.Invoices.Factories;
using BionicInventory.Application.Invoices.Interfaces;
using BionicInventory.Application.Invoices.InvoicePayment.Commands;
using BionicInventory.Application.Invoices.InvoicePayment.Factories;
using BionicInventory.Application.Invoices.InvoicePayment.Interfaces;
using BionicInventory.Application.Invoices.InvoicePayment.Queries;
using BionicInventory.Application.Invoices.Queries;
using BionicInventory.Application.Models;
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
using BionicInventory.Application.Products.ProductGroups.Commands;
using BionicInventory.Application.Products.ProductGroups.Factories;
using BionicInventory.Application.Products.ProductGroups.Interfaces;
using BionicInventory.Application.Products.ProductGroups.Queries;
using BionicInventory.Application.Products.Queries;
using BionicInventory.Application.SalesOrders.Commands;
using BionicInventory.Application.SalesOrders.Factory;
using BionicInventory.Application.SalesOrders.Interfaces;
using BionicInventory.Application.SalesOrders.Queries;
using BionicInventory.Application.SalesOrders.Queries.Report;
using BionicInventory.Application.Security.Roles.Models;
using BionicInventory.Application.Shared.Infrastructure;
using BionicInventory.Application.Users.Models;
using BionicInventory.API.Commons;
using BionicInventory.API.Controllers.WorkOrders;
using BionicInventory.API.Controllers.WorkOrders.Interface;
using BionicInventory.API.Settings;
using BionicInventory.DataStore;
using BionicInventory.Domain.Identity;
using BionicInventory.Domain.Items;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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

            services.AddScoped<IInventoryDatabaseService, DatabaseService> ();
            services.AddDbContext<DatabaseService> ();

            services.AddScoped<ICustomersQuery, CustomersQuery> ();
            services.AddScoped<ICustomersCommand, CustomersCommand> ();
            services.AddScoped<ICustomersFactory, CustomerFactories> ();
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
            services.AddScoped<IStockBookingCommand, StockBookingCommand> ();
            services.AddScoped<IStockBookingFactory, StockBookingFactory> ();
            services.AddScoped<IInvoicesQuery, InvoicesQuery> ();
            services.AddScoped<IInvoicesCommand, InvoicesCommand> ();
            services.AddScoped<IInvoiceFactory, InvoiceFactory> ();
            services.AddScoped<IInvoicePaymentCommand, InvoicePaymentCommand> ();
            services.AddScoped<IInvoicePaymentFactory, InvoicePaymentFactory> ();
            services.AddScoped<IInvoicePaymentQuery, InvoicePaymentQuery> ();
            services.AddScoped<IWorkOrder, WorkOrdersController> ();
            services.AddScoped<IDashboardQuery, DashboardQuery> ();
            services.AddScoped<IProductGroupQuery, ProductGroupQuery> ();
            services.AddScoped<IProductGroupCommand, ProductGroupCommand> ();
            services.AddScoped<IProductGroupFactory, ProductGroupFactory> ();

            services.AddAuthentication (options => {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer (options => {
                    options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes (Configuration["Jwt:Key"]))
                    };
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = true;
                });

            services.AddMediatR (typeof (DeleteProductGroupCommandHandler).GetTypeInfo ().Assembly);
            //add identity and create the db
            services.AddIdentityCore<ApplicationUser> (options => { });
            new IdentityBuilder (typeof (ApplicationUser), typeof (ApplicationRole), services)
                .AddRoleManager<RoleManager<ApplicationRole>> ()
                .AddSignInManager<SignInManager<ApplicationUser>> ()
                .AddEntityFrameworkStores<DatabaseService> ()
                .AddDefaultTokenProviders ();

            services.AddTransient (typeof (IPipelineBehavior<,>), typeof (RequestPreProcessorBehavior<,>));
            services.AddTransient (typeof (IPipelineBehavior<,>), typeof (ReuquestPerformaceLogger<,>));
            // services.AddTransient (typeof (IPipelineBehavior<,>), typeof (RequestValidationManager<,>));

            // Add MediatR

            services.AddSwaggerDocument ();

            services.AddSingleton<ISystemFunctionDiscovery, MvcControllerDiscovery> ();
            services.AddCors (options => {
                options.AddPolicy ("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin ().AllowAnyMethod ().AllowAnyHeader ());
            });

            services.AddMvc (
                    options => {
                        var policy = new AuthorizationPolicyBuilder ()
                            .RequireAuthenticatedUser ()
                            .Build ();
                        options.Filters.Add (new AuthorizeFilter (policy));
                        options.Filters.Add (typeof (DynamicAuthorizationFilter));
                        options.Filters.Add (new ModelValidationFilter ());

                        // Self referencing loop detected for property entity framework solution
                        options.OutputFormatters.Clear ();
                        options.OutputFormatters.Add (new JsonOutputFormatter (new JsonSerializerSettings () {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        }, ArrayPool<char>.Shared));
                    }
                ).AddJsonOptions (options => options.SerializerSettings.ContractResolver = new DefaultContractResolver ())
                .SetCompatibilityVersion (CompatibilityVersion.Version_2_2);

            services.Configure<IdentityOptions> (options => {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 0;
                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes (5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) {

            // loggerFactory.AddConsole();

            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
                app.UseDatabaseErrorPage ();
            } else {
                app.UseExceptionHandler ("/Error");
            }

            app.UseAuthentication ();
            app.UseCors ("AllowAllOrigins");

            app.UseMvc ();
            app.UseSwagger ();
            app.UseSwaggerUi3 (settings => {
                settings.ServerUrl = "/swagger/v1/swagger.json";
            });

        }
    }
}