/*
 * @CreateTime: Sep 10, 2018 8:39 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 18, 2019 10:04 PM
 * @Description: Modify Here, Please 
 */
using System.Threading.Tasks;
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
using Microsoft.EntityFrameworkCore;

namespace Bionic_inventory.Application.Interfaces {

    public interface IInventoryDatabaseService {

        DbSet<Address> Address { get; set; }
        DbSet<Customer> Customer { get; set; }
        DbSet<Company> Company { get; set; }
        DbSet<Employee> Employee { get; set; }
        DbSet<FinishedProduct> FinishedProduct { get; set; }
        DbSet<Invoice> Invoice { get; set; }
        DbSet<InvoiceDetail> InvoiceDetail { get; set; }
        DbSet<InvoicePayments> InvoicePayments { get; set; }
        DbSet<ShipmentDetail> ShipmentDetail { get; set; }
        DbSet<Shipment> Shipment { get; set; }
        DbSet<Item> Item { get; set; }
        DbSet<PhoneNumber> PhoneNumber { get; set; }
        DbSet<ProductionOrderList> ProductionOrderList { get; set; }
        DbSet<CustomerOrder> CustomerOrder { get; set; }
        DbSet<CustomerOrderItem> CustomerOrderItem { get; set; }
        DbSet<SocialMedia> SocialMedia { get; set; }
        DbSet<BookedStockItems> BookedStockItems { get; set; }
        DbSet<Bom> Bom { get; set; }
        DbSet<BomItems> BomItems { get; set; }
        DbSet<ProductGroup> ProductGroup { get; set; }
        DbSet<UnitOfMeasurment> UnitsOfMeasurment { get; set; }
        DbSet<Workstation> WorkStation { get; set; }
        DbSet<WorkstationGroup> WorkStationGroup { get; set; }
        DbSet<Routing> Routing { get; set; }
        DbSet<RoutingOperation> RoutingDetail { get; set; }
        DbSet<StorageLocation> StorageLocation { get; set; }
        DbSet<RoutingBoms> RoutingBoms { get; set; }
        DbSet<WriteOff> WriteOff { get; set; }
        DbSet<WriteOffDetail> WriteOffDetail { get; set; }

        DbSet<Vendor> Vendor { get; set; }
        DbSet<VendorPurchaseTerm> VendorPurchaseTerm { get; set; }
        DbSet<StockBatch> StockBatch { get; set; }
        DbSet<StockBatchStorage> StockBatchStorage { get; set; }
        DbSet<BookedStockBatch> BookedStockBatch { get; set; }

        DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        DbSet<PurchaseOrderQuotation> PurchaseOrderQuotation { get; set; }
        DbSet<SystemSettings> SystemSettings { get; set; }
        DbSet<AspNetRoleClaims> RoleClaims { get; set; }
        DbSet<ApplicationRole> Roles { get; set; }
        DbSet<AspNetUserClaims> UserClaims { get; set; }
        DbSet<AspNetUserLogins> UserLogins { get; set; }
        DbSet<AspNetUserRoles> UserRoles { get; set; }
        DbSet<ApplicationUser> Users { get; set; }
        DbSet<AspNetUserTokens> UserTokens { get; set; }

        void Save ();
        Task SaveAsync ();

    }

}