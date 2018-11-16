/*
 * @CreateTime: Oct 2, 2018 8:32 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 15, 2018 7:36 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.Employees;
using BionicInventory.Domain.FinishedProducts;
using BionicInventory.Domain.Invoices.InvoiceDetails;
using BionicInventory.Domain.PurchaseOrders;
using BionicInventory.Domain.Shipments.ShipmentDetails;

namespace BionicInventory.Domain.Shipments {
    public class Shipment {

        public Shipment () {
            ShipmentDetail = new HashSet<ShipmentDetail> ();
        }

        public uint Id { get; set; }
        public uint BookedBy { get; set; }
        public string ShipmentNote { get; set; }

        public DateTime DeliveryDate { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateAdded { get; set; }
        public uint CustomerOrderId { get; set; }
        public string Status { get; set; }

        public Employee BookedByNavigation { get; set; }
        public PurchaseOrder CustomerOrder { get; set; }
        public ICollection<ShipmentDetail> ShipmentDetail { get; set; }
    }
}