using Bionic_inventory.Application.Interfaces;
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
using BionicInventory.DataStore.ProductionOrders;
using BionicInventory.DataStore.ProductionOrders.ProductionOrderLists;
using BionicInventory.DataStore.PurchaseOrders;
using BionicInventory.DataStore.PurchaseOrders.PurchaseOrderDetails;
using BionicInventory.DataStore.Sale;
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
using BionicInventory.Domain.Items.ItemPrices;
using BionicInventory.Domain.ProductionOrders;
using BionicInventory.Domain.ProductionOrders.ProductionOrderLists;
using BionicInventory.Domain.PurchaseOrders;
using BionicInventory.Domain.PurchaseOrders.PurchaseOrderDetails;
using BionicInventory.Domain.Sale;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.DataStore {
    public partial class DatabaseService : DbContext, IInventoryDatabaseService {
        public DatabaseService () { }

        public DatabaseService (DbContextOptions<DatabaseService> options) : base (options) { }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseMySql ("server=localhost;database=bionic_inventory;user=mikael;port=3306;",
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
        public DbSet<ItemPrice> ItemPrice { get; set; }
        public DbSet<PhoneNumber> PhoneNumber { get; set; }
        public DbSet<ProductionOrder> ProductionOrder { get; set; }
        public DbSet<ProductionOrderList> ProductionOrderList { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
        public DbSet<FinishedProduct> FinishedProduct { get; set; }
        public DbSet<Sales> Sale { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating (modelBuilder);
            
            modelBuilder.ApplyConfiguration(new SalesConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration (new CustomerConfiguration ());
            modelBuilder.ApplyConfiguration (new EmployeeConfiguration ());
            modelBuilder.ApplyConfiguration (new ItemConfiguration ());
            modelBuilder.ApplyConfiguration (new PurchaseOrderConfiguration ());
            modelBuilder.ApplyConfiguration (new PurchaseOrderDetailConfiguration ());
            modelBuilder.ApplyConfiguration (new ProductionOrderConfiguration ());
            modelBuilder.ApplyConfiguration (new ProductionOrderListConfiguration ());
            modelBuilder.ApplyConfiguration (new AddressConfiguration ());
            modelBuilder.ApplyConfiguration (new SocialMediaConfiguration ());
            modelBuilder.ApplyConfiguration (new PhoneNumberConfiguration ());
            modelBuilder.ApplyConfiguration (new InvoiceConfiguration ());
            modelBuilder.ApplyConfiguration (new InvoiceDetailConfiguration ());
            modelBuilder.ApplyConfiguration (new InvoicePaymentsConfiguration ());
            modelBuilder.ApplyConfiguration (new FinishedProductConfiguration ());
            

        }

        public void Save () {
            this.SaveChanges ();
        }

    }
}