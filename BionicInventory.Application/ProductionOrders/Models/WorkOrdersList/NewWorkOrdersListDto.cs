/*
 * @CreateTime: Sep 10, 2018 8:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2018 8:33 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.ProductionOrders.Models.WorkOrdersList
{
    public class NewWorkOrdersListDto
    {
        public uint productionOrderId;
        public uint itemId;
        public uint quantity;
        public float costPerItem;
        public DateTime dueDate;
        public bool? complete;
    }
}