/*
 * @CreateTime: Nov 15, 2018 8:02 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 15, 2018 10:06 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;

namespace BionicInventory.Application.Shipments.Models.ViewModels {
    public class ShipmentDetailView : ShipmentStatusView {

        public List<ShipmentItemStatusView> shipmentItem = new List<ShipmentItemStatusView> ();
    }
}