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
using BionicInventory.Domain.CustomerOrders;
using BionicInventory.Domain.Employees;
using BionicInventory.Domain.FinishedProducts;
using BionicInventory.Domain.Invoices.InvoiceDetails;

namespace BionicInventory.Domain.Shipments {
    public partial class Shipment {
        public Shipment () {
            ShipmentDetail = new HashSet<ShipmentDetail> ();
        }

        public uint Id { get; set; }
        public uint? BookedBy { get; set; }
        public string ShipmentNote { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryAddress { get; set; }
        public string WaybillNote { get; set; }
        public string PickingListNote { get; set; }
        public string Status { get; set; }

        public virtual ICollection<ShipmentDetail> ShipmentDetail { get; set; }
    }
}