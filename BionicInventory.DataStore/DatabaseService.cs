/*
 * @CreateTime: Nov 14, 2018 10:57 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 18, 2019 10:05 PM
 * @Description: Modify Here, Please 
 */
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Models;
using BionicInventory.Application.Security.Roles.Models;
using BionicInventory.Application.Users.Models;
using BionicInventory.DataStore.BookedStockItem;
using BionicInventory.DataStore.Companies;
using BionicInventory.DataStore.CustomerOrders;
using BionicInventory.DataStore.Customers;
using BionicInventory.DataStore.Customers.Addresses;
using BionicInventory.DataStore.Customers.PhoneNumbers;
using BionicInventory.DataStore.Customers.SocialMedias;
using BionicInventory.DataStore.Employees;
using BionicInventory.DataStore.FinishedProducts;
using BionicInventory.DataStore.Identity;
using BionicInventory.DataStore.Invoices;
using BionicInventory.DataStore.Items;
using BionicInventory.DataStore.Items.BOM;
using BionicInventory.DataStore.Items.Routings;
using BionicInventory.DataStore.Procurment.PurchaseOrders;
using BionicInventory.DataStore.ProductionOrders;
using BionicInventory.DataStore.ProductionOrders.ProductionOrderLists;
using BionicInventory.DataStore.PurchaseOrders;
using BionicInventory.DataStore.Settings;
using BionicInventory.DataStore.Shipments;
using BionicInventory.DataStore.StockBatchs;
using BionicInventory.DataStore.StorageLocations;
using BionicInventory.DataStore.UnitOfMeasurments;
using BionicInventory.DataStore.Vendors;
using BionicInventory.DataStore.Workstations;
using BionicInventory.DataStore.WriteOffs;
using BionicInventory.Domain.BookedStockItem;
using BionicInventory.Domain.Companies;
using BionicInventory.Domain.CustomerOrders;
using BionicInventory.Domain.Customers;
using BionicInventory.Domain.Customers.Addresses;
using BionicInventory.Domain.Customers.PhoneNumbers;
using BionicInventory.Domain.Customers.SocialMedias;
using BionicInventory.Domain.Employees;
using BionicInventory.Domain.FinishedProducts;
using BionicInventory.Domain.Identity;
using BionicInventory.Domain.Invoices;
using BionicInventory.Domain.Invoices.InvoiceDetails;
using BionicInventory.Domain.Invoices.InvoicePayment;
using BionicInventory.Domain.Items;
using BionicInventory.Domain.Items.BOMs;
using BionicInventory.Domain.Items.Rotings;
using BionicInventory.Domain.Procurment.PurchaseOrders;
using BionicInventory.Domain.Procurment.Vendors;
using BionicInventory.Domain.ProductionOrders;
using BionicInventory.Domain.Routings;
using BionicInventory.Domain.Settings;
using BionicInventory.Domain.Shipments;
using BionicInventory.Domain.Storages;
using BionicInventory.Domain.UnitOfMeasurments;
using BionicInventory.Domain.Workstations;
using BionicProduction.Domain.StockBatchs;
using BionicProduction.Domain.WriteOffs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.DataStore {
    public partial class DatabaseService : IdentityDbContext<ApplicationUser, ApplicationRole, string, AspNetUserClaims, AspNetUserRoles, AspNetUserLogins, AspNetRoleClaims, AspNetUserTokens>, IInventoryDatabaseService {
        public DatabaseService () { }
        public DatabaseService (DbContextOptions<DatabaseService> options) : base (options) {
            //   DataBase.SetInitializer(new AccountingDatabaseInitializer());
        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseMySql ("server=localhost;database=bionic_inventory;user=admin;password=admin;port=3306;",
                    x => x.MigrationsAssembly ("DataStore.Migrations"));
            }
        }
        public DbSet<Address> Address { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetail { get; set; }
        public DbSet<InvoicePayments> InvoicePayments { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<PhoneNumber> PhoneNumber { get; set; }
        public DbSet<ProductionOrderList> ProductionOrderList { get; set; }
        public DbSet<CustomerOrder> CustomerOrder { get; set; }
        public DbSet<CustomerOrderItem> CustomerOrderItem { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
        public DbSet<FinishedProduct> FinishedProduct { get; set; }
        public DbSet<ShipmentDetail> ShipmentDetail { get; set; }
        public DbSet<Shipment> Shipment { get; set; }
        public DbSet<BookedStockItems> BookedStockItems { get; set; }
        public DbSet<Bom> Bom { get; set; }
        public DbSet<BomItems> BomItems { get; set; }
        public DbSet<ProductGroup> ProductGroup { get; set; }
        public DbSet<UnitOfMeasurment> UnitsOfMeasurment { get; set; }
        public DbSet<Workstation> WorkStation { get; set; }
        public DbSet<Routing> Routing { get; set; }
        public DbSet<RoutingOperation> RoutingDetail { get; set; }
        public DbSet<RoutingBoms> RoutingBoms { get; set; }
        public DbSet<WorkstationGroup> WorkStationGroup { get; set; }
        public DbSet<StorageLocation> StorageLocation { get; set; }
        public DbSet<WriteOff> WriteOff { get; set; }
        public DbSet<WriteOffDetail> WriteOffDetail { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrder { get; set; }

        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<VendorPurchaseTerm> VendorPurchaseTerm { get; set; }
        public DbSet<StockBatch> StockBatch { get; set; }
        public DbSet<StockBatchStorage> StockBatchStorage { get; set; }
        public DbSet<BookedStockBatch> BookedStockBatch { get; set; }
        public DbSet<SystemSettings> SystemSettings { get; set; }

        public new DbSet<AspNetRoleClaims> RoleClaims { get; set; }
        public new DbSet<ApplicationRole> Roles { get; set; }
        public new DbSet<AspNetUserClaims> UserClaims { get; set; }
        public new DbSet<AspNetUserLogins> UserLogins { get; set; }
        public new DbSet<AspNetUserRoles> UserRoles { get; set; }
        public new DbSet<ApplicationUser> Users { get; set; }
        public new DbSet<AspNetUserTokens> UserTokens { get; set; }
        public DbSet<PurchaseOrderQuotation> PurchaseOrderQuotation { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating (modelBuilder);

            modelBuilder.ApplyConfiguration (new ShipmentsConfiguration ());
            modelBuilder.ApplyConfiguration (new ShipmentDetailsConfiguration ());
            modelBuilder.ApplyConfiguration (new CompanyConfiguration ());
            modelBuilder.ApplyConfiguration (new CustomerConfiguration ());
            modelBuilder.ApplyConfiguration (new EmployeeConfiguration ());
            modelBuilder.ApplyConfiguration (new ItemConfiguration ());
            modelBuilder.ApplyConfiguration (new CustomerOrderConfiguration ());
            modelBuilder.ApplyConfiguration (new CustomerOrderItemConfiguration ());
            modelBuilder.ApplyConfiguration (new ProductionOrderListConfiguration ());
            modelBuilder.ApplyConfiguration (new AddressConfiguration ());
            modelBuilder.ApplyConfiguration (new SocialMediaConfiguration ());
            modelBuilder.ApplyConfiguration (new PhoneNumberConfiguration ());
            modelBuilder.ApplyConfiguration (new InvoiceConfiguration ());
            modelBuilder.ApplyConfiguration (new InvoiceDetailConfiguration ());
            modelBuilder.ApplyConfiguration (new InvoicePaymentsConfiguration ());
            modelBuilder.ApplyConfiguration (new FinishedProductConfiguration ());
            modelBuilder.ApplyConfiguration (new BookedStockItemConfiguration ());
            modelBuilder.ApplyConfiguration (new BillOfMaterialsConfigurations ());
            modelBuilder.ApplyConfiguration (new ProductGroupsConfigurations ());
            modelBuilder.ApplyConfiguration (new UnitOfMeasurmentsConfigurations ());
            modelBuilder.ApplyConfiguration (new BillOfMaterialItemsConfigurations ());
            modelBuilder.ApplyConfiguration (new WorkstationConfiguration ());
            modelBuilder.ApplyConfiguration (new RoutingConfiguration ());
            modelBuilder.ApplyConfiguration (new RoutingOperationConfiguration ());
            modelBuilder.ApplyConfiguration (new WorkstationGroupConfiguration ());
            modelBuilder.ApplyConfiguration (new StorageLocationConfiguration ());
            modelBuilder.ApplyConfiguration (new RoutingBomsConfiguration ());
            modelBuilder.ApplyConfiguration (new VendorConfiguration ());
            modelBuilder.ApplyConfiguration (new VendorPurchaseTermConfiguration ());
            modelBuilder.ApplyConfiguration (new WriteOffConfiguration ());
            modelBuilder.ApplyConfiguration (new WriteOffDetailConfiguration ());
            modelBuilder.ApplyConfiguration (new StockBatchConfiguration ());
            modelBuilder.ApplyConfiguration (new StockBatchStorageConfiguration ());
            modelBuilder.ApplyConfiguration (new BookedStockBatchConfiguration ());
            modelBuilder.ApplyConfiguration (new PurchaseOrderConfiguration ());
            modelBuilder.ApplyConfiguration (new PurchaseOrderQuotationConfiguration ());
            modelBuilder.ApplyConfiguration (new SystemSettingsConfiguration ());
            modelBuilder.ApplyConfiguration (new AspNetUserConfiguration ());
            modelBuilder.ApplyConfiguration (new AspNetRoleClaimsConfiguration ());
            modelBuilder.ApplyConfiguration (new AspNetRolesConfiguration ());
            modelBuilder.ApplyConfiguration (new AspNetUserClaimsConfiguration ());
            modelBuilder.ApplyConfiguration (new AspNetUserLoginsConfiguration ());
            modelBuilder.ApplyConfiguration (new AspNetUserRolesConfiguration ());
            modelBuilder.ApplyConfiguration (new AspNetUserTokensConfiguration ());

        }

        public void Save () {
            this.SaveChanges ();
        }

        public Task SaveAsync () {
            return this.SaveChangesAsync ();
        }

    }
}