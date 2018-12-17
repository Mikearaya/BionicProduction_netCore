/*
 * @CreateTime: Nov 14, 2018 10:57 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 17, 2018 10:51 PM
 * @Description: Modify Here, Please 
 */
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.DataStore.BookedStockItem;
using BionicInventory.DataStore.Companies;
using BionicInventory.DataStore.Customers;
using BionicInventory.DataStore.Customers.Addresses;
using BionicInventory.DataStore.Customers.PhoneNumbers;
using BionicInventory.DataStore.Customers.SocialMedias;
using BionicInventory.DataStore.Employees;
using BionicInventory.DataStore.FinishedProducts;
using BionicInventory.DataStore.Invoices;
using BionicInventory.DataStore.Invoices.InvoiceDetails;
using BionicInventory.DataStore.Invoices.InvoicePayment;
using BionicInventory.DataStore.Items;
using BionicInventory.DataStore.Items.BOM;
using BionicInventory.DataStore.Items.Routings;
using BionicInventory.DataStore.ProductionOrders;
using BionicInventory.DataStore.ProductionOrders.ProductionOrderLists;
using BionicInventory.DataStore.PurchaseOrders;
using BionicInventory.DataStore.PurchaseOrders.PurchaseOrderDetails;
using BionicInventory.DataStore.Shipments;
using BionicInventory.DataStore.Shipments.ShipmentDetails;
using BionicInventory.DataStore.StorageLocations;
using BionicInventory.DataStore.UnitOfMeasurments;
using BionicInventory.DataStore.Workstations;
using BionicInventory.Domain.BookedStockItem;
using BionicInventory.Domain.Companies;
using BionicInventory.Domain.Customers;
using BionicInventory.Domain.Customers.Addresses;
using BionicInventory.Domain.Customers.PhoneNumbers;
using BionicInventory.Domain.Customers.SocialMedias;
using BionicInventory.Domain.Employees;
using BionicInventory.Domain.FinishedProducts;
using BionicInventory.Domain.Invoices;
using BionicInventory.Domain.Invoices.InvoiceDetails;
using BionicInventory.Domain.Invoices.InvoicePayment;
using BionicInventory.Domain.Items;
using BionicInventory.Domain.Items.BOMs;
using BionicInventory.Domain.Items.Rotings;
using BionicInventory.Domain.ProductionOrders;
using BionicInventory.Domain.ProductionOrders.ProductionOrderLists;
using BionicInventory.Domain.PurchaseOrders;
using BionicInventory.Domain.PurchaseOrders.PurchaseOrderDetails;
using BionicInventory.Domain.Routings;
using BionicInventory.Domain.Shipments;
using BionicInventory.Domain.Shipments.ShipmentDetails;
using BionicInventory.Domain.Storages;
using BionicInventory.Domain.UnitOfMeasurments;
using BionicInventory.Domain.Workstations;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.DataStore {
    public partial class DatabaseService : DbContext, IInventoryDatabaseService {
        public DatabaseService () { }

        public DatabaseService (DbContextOptions<DatabaseService> options) : base (options) { }

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
        public DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
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

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating (modelBuilder);

            modelBuilder.ApplyConfiguration (new ShipmentsConfiguration ());
            modelBuilder.ApplyConfiguration (new ShipmentDetailsConfiguration ());
            modelBuilder.ApplyConfiguration (new CompanyConfiguration ());
            modelBuilder.ApplyConfiguration (new CustomerConfiguration ());
            modelBuilder.ApplyConfiguration (new EmployeeConfiguration ());
            modelBuilder.ApplyConfiguration (new ItemConfiguration ());
            modelBuilder.ApplyConfiguration (new PurchaseOrderConfiguration ());
            modelBuilder.ApplyConfiguration (new PurchaseOrderDetailConfiguration ());
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

        }

        public void Save () {
            this.SaveChanges ();
        }

        public Task SaveAsync () {
            return this.SaveChangesAsync();
        }

    }
}