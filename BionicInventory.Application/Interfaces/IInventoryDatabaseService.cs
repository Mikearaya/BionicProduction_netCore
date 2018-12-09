/*
 * @CreateTime: Sep 10, 2018 8:39 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 9, 2018 11:40 PM
 * @Description: Modify Here, Please 
 */
using System.Threading.Tasks;
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
using BionicInventory.Domain.Shipments;
using BionicInventory.Domain.Shipments.ShipmentDetails;
using BionicInventory.Domain.UnitOfMeasurments;
using BionicInventory.Domain.Workstations;
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
        DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        DbSet<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
        DbSet<SocialMedia> SocialMedia { get; set; }
        DbSet<BookedStockItems> BookedStockItems { get; set; }
        DbSet<Bom> Bom { get; set; }
        DbSet<BomItems> BomItems { get; set; }
        DbSet<ProductGroup> ProductGroup { get; set; }
        DbSet<UnitOfMeasurment> UnitsOfMeasurment { get; set; }
        DbSet<Workstation> WorkStation { get; set; }
        DbSet<Routing> Routing { get; set; }
        DbSet<RoutingDetail> RoutingDetail { get; set; }

        void Save ();
        Task SaveAsync ();

    }

}