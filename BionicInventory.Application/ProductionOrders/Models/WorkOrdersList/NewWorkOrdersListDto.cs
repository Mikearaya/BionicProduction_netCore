/*
 * @CreateTime: Sep 10, 2018 8:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 11, 2018 1:37 AM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.ProductionOrders.Models.WorkOrdersList
{
    public class NewWorkOrdersListDto
    {
        public uint ItemId {get; set;}
        public uint Quantity {get; set;}
        public float CostPerItem {get; set;}
        public DateTime DueDate {get; set;}
        public bool? Complete {get; set;}

        public NewWorkOrderDto NewWorkOrderDto {get; set;}

    }
}