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
            var shipmentStatusQuarable = _database.Shipment.Select (s => new {
                id = s.Id,
                    CustomerOrderId = s.CustomerOrderId,
                    bookingUser = s.BookedByNavigation.FullName (),
                    bookingUserId = s.BookedBy,
                    deliveryDate = s.DeliveryDate,
                    dateAdded = s.DateAdded,
                    dateUpdated = s.DateUpdated,
                    picked = s.ShipmentDetail.Count (d => d.Picked == 1),
                    total = s.ShipmentDetail.Count

            });

            List<ShipmentStatusView> shipmentStatus = new List<ShipmentStatusView> ();
            foreach (var item in shipmentStatusQuarable) {

                shipmentStatus.Add (new ShipmentStatusView () {
                    id = item.id,
                        CustomerOrderId = item.CustomerOrderId,
                        bookingUser = item.bookingUser,
                        bookingUserId = item.bookingUserId,
                        deliveryDate = item.deliveryDate,
                        dateAdded = item.dateAdded,
                        dateUpdated = item.dateUpdated,
                        status = CalculateStatus (item.total, item.picked)

                });
            }

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
                        totalShiped = (int?) d.ShipmentDetail.Count (),
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

        public List<FinishedProduct> GetUnshipedCustomerOrderItems (uint orderItemId, int quantity) {
            return _database.FinishedProduct
                .Where (f => f.ShipmentDetail == null &&
                    f.BookedStockItems.BookedFor == orderItemId || f.Order.PurchaseOrderId == orderItemId)
                .Take (quantity)
                .ToList ();
        }

        public IEnumerable<ShipmentsSummaryView> GetCustomerOrderShipmentsSummary (uint customerOrderId) {
            return _database.Shipment
                .Where (s => s.CustomerOrderId == customerOrderId)
                .Select (s => new ShipmentsSummaryView () {
                    dateAdded = s.DateAdded,
                        deliveryDate = s.DeliveryDate,
                        id = s.Id
                }).ToList ();
        }

        public ShipmentDetailView GetShipmentDetails (uint shipmentId) {
            var detail = _database.Shipment
                .Where (s => s.Id == shipmentId)
                .Select (s => new {
                    shipmentId = s.Id,
                        user = s.BookedByNavigation.FullName (),
                        deliveryDate = s.DeliveryDate,
                        added = s.DateAdded,
                        updated = s.DateUpdated,
                        orderId = s.CustomerOrderId,
                        bookingId = s.BookedBy,
                        shipmentItem = s.ShipmentDetail.GroupBy (d => d.ShipmentId)
                        .Select (de => new {
                            total = de.Count (),
                                shiped = de.Count (p => p.Picked == 1),

                                items = de.Select (det => new {
                                    orderItemId = det.OrderItemId,
                                        itemName = det.OrderItem.Item.Name,
                                }),

                        })
                }).FirstOrDefault ();

            ShipmentDetailView shipmentDetail = new ShipmentDetailView () {
                id = detail.shipmentId,
                CustomerOrderId = detail.orderId,
                bookingUserId = detail.bookingId,
                bookingUser = detail.user,
                deliveryDate = detail.deliveryDate,
                dateAdded = detail.added,
                dateUpdated = detail.updated,
            };

            var totalBooked = 0;
            var totalShiped = 0;

            foreach (var list in detail.shipmentItem) {

                ShipmentItemStatusView itemDetail = new ShipmentItemStatusView () {
                    shippedQuantity = list.shiped,
                    remainingShipments = list.total - list.shiped,
                    pickedQuantity = list.shiped,
                    bookedQuantity = list.total,
                    status = CalculateStatus (list.total, list.shiped)
                };

                foreach (var shipments in list.items) {
                    itemDetail.customerOrderItemId = shipments.orderItemId;
                    itemDetail.itemName = shipments.itemName;
                }

                shipmentDetail.shipmentItem.Add (itemDetail);

                totalBooked += list.total;
                totalShiped += list.shiped;
            }

            shipmentDetail.status = CalculateStatus (totalBooked, totalShiped);

            return shipmentDetail;
        }

        private string CalculateStatus (int total, int picked) {
            var status = "";
            if (total - picked == 0) {
                status = "picked";
            } else if (picked != 0 && total > picked) {
                status = "Partially Shipped";
            } else if (total != 0 && picked == 0) {
                status = "Ready for Shipment";
            }

            return status;
        }
    }
}