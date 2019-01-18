/*
 * @CreateTime: Sep 10, 2018 8:32 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 18, 2018 10:02 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Interfaces;
using BionicInventory.Application.ProductionOrders.Models;
using BionicInventory.Domain.ProductionOrders;

namespace BionicInventory.Application.ProductionOrders.Iterfaces {
    public interface IWorkOrdersQuery {

        ProductionOrderList GetWorkOrderById (uint id);
        WorkOrderView GetWorkOrderItemById (uint id);
        IEnumerable<ActiveOrdersView> GetActiveWorkOrders ();
        IEnumerable<WorkOrderView> GetWorkOrdersStatus ();
        IEnumerable<ProductionOrderList> GetAllWorkOrders ();
        bool saleOrderProductionExits (uint id);
        IEnumerable<ProductionOrderList> GetCompletedWorkOrders ();
        WorkOrderView GetPendingWorkOrder (uint manufactureRequestId);

        IEnumerable<WorkOrderView> GetPendingWorkOrders ();

    }
}