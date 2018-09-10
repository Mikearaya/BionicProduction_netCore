/*
 * @CreateTime: Sep 10, 2018 10:18 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2018 10:18 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.ProductionOrders.Models.WorkOrdersList {
    public class UpdatedWorkOrdersListDto {

        public uint Id;
        public uint ProductionOrderId;
        public uint ItemId;
        public uint Quantity;
        public float CostPerItem;
        public DateTime DueDate;
        public bool? Complete;
    }
}