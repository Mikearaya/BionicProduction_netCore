using System;
using System.Collections.Generic;
using System.Linq;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shipments.Interfaces;
using BionicInventory.Application.Shipments.Models.ViewModels;
using BionicInventory.Domain.FinishedProducts;
using BionicInventory.Domain.Shipments;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.Shipments.Queries {
    public class ShipmentQuery : IShipmentQuery {
        private readonly IInventoryDatabaseService _database;

        public ILogger<ShipmentQuery> _logger { get; }

        public ShipmentQuery (IInventoryDatabaseService database,
            ILogger<ShipmentQuery> logger) {
            _database = database;
            _logger = logger;
        }
        public IEnumerable<Shipment> GetAllShipments () {
            return _database.Shipment
                .Include (s => s.ShipmentDetail)
                .ToList ();
        }

        public IEnumerable<ShipmentStatusView> GetAllShipmentStatus () {
            var shipmentStatus = _database.Shipment.Select (s => new ShipmentStatusView () {
                id = s.Id,
                    CustomerOrderId = s.CustomerOrderId,
                    bookingUser = s.BookedByNavigation.FullName (),
                    bookingUserId = s.BookedBy,
                    deliveryDate = s.DeliveryDate,
                    dateAdded = s.DateAdded,
                    dateUpdated = s.DateUpdated,
            

            }).ToList ();

            return shipmentStatus;
        }

        public IEnumerable<Shipment> GetCustomerOrderShipments (uint customerOrderId) {
            return _database.Shipment
                .Where (s => s.CustomerOrderId == customerOrderId)
                .Include (s => s.ShipmentDetail)
                .ToList ();
        }

        public IEnumerable<CustomerOrderShipmentDetail> GetCustomerOrderShipmentStatus (uint customerOrderId) {
            return _database.PurchaseOrderDetail
                .Where (co => co.PurchaseOrderId == customerOrderId)
                .Select (d => new CustomerOrderShipmentDetail () {
                    avalableForShipment = (int?) d.BookedStockItems.Count (b => b.Stock.ShipmentDetail == null) +
                        (int?) d.ProductionOrderList.FinishedProduct.Count (b => b.ShipmentDetail == null),
                        itemId = d.ItemId,
                        totalBooked = (int?) d.BookedStockItems.Count () + (int?) d.ProductionOrderList.Quantity,
                        itemName = d.Item.Name,
                        totalShiped = (int?) d.ShipmentDetail.Count(),
                        orderQuantity = (int?) d.Quantity,
                        customerOrderId = d.PurchaseOrderId,
                        customerOrderItemId = d.Id,

                });

        }

        public Shipment GetShipmentById (uint id) {
            return _database.Shipment
                .Where (s => s.Id == id)
                .Include (s => s.ShipmentDetail)
                .FirstOrDefault ();
        }

        public IEnumerable<FinishedProduct> GetUnshipedCustomerOrderItems (uint orderItemId, int quantity) {
            return _database.FinishedProduct
                .Where (f => f.ShipmentDetail == null &&
                    f.BookedStockItems.BookedFor == orderItemId || f.Order.PurchaseOrderId == orderItemId)
                    .Take(quantity);
        }
    }
}