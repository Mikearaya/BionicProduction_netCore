/*
 * @CreateTime: Nov 17, 2018 9:26 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 17, 2018 9:56 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.Shipments.Models.ViewModels {
    public class ShipmentsSummaryView {
        public uint id { get; set; }
        public DateTime? dateAdded { get; set; }
        public DateTime deliveryDate { get; set; }
    }
}