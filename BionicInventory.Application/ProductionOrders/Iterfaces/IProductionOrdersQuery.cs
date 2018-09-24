/*
 * @CreateTime: Sep 10, 2018 8:32 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2018 11:03 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Interfaces;
using BionicInventory.Application.ProductionOrders.Models;
using BionicInventory.Domain.ProductionOrders;
using BionicInventory.Domain.ProductionOrders.ProductionOrderLists;

namespace BionicInventory.Application.ProductionOrders.Iterfaces {
    public interface IWorkOrdersQuery {

        ProductionOrder GetWorkOrderById(uint id);
        ProductionOrderList GetWorkOrderItemById(uint id);
        IEnumerable<ActiveOrdersView> GetActiveWorkOrders();
        IEnumerable<WorkOrderView> GetWorkOrdersStatus();
        IEnumerable<ProductionOrder> GetAllWorkOrders();
        IEnumerable<ProductionOrder> GetCompletedWorkOrders();

    }
}