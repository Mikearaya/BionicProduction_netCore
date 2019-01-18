/*
 * @CreateTime: Sep 10, 2018 8:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 18, 2018 10:27 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Application.ProductionOrders.Models;
using BionicInventory.Domain.ProductionOrders;

namespace BionicInventory.Application.ProductionOrders.Iterfaces {
    public interface IWorkOrdersFactory {
        ProductionOrderList CreateNewWorkOrder (NewWorkOrderDto newOrder);

        ProductionOrderList CreateUpdatedWorkOrder (UpdatedWorkOrderDto newOrder);

        WorkOrderView CreateWorkOrderView (ProductionOrderList workOrder);
        WorkOrderView CreateSingleWorkOrderView (ProductionOrderList workOrder);
        NewWorkOrderDto CreateCustomerOrderDto (uint customerOrderId, uint itemId, uint quantity, DateTime startDate, DateTime endDate, uint bookedBy, string description = "");
        uint ExtractId (string id);
    }
}