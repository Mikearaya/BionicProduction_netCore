/*
 * @CreateTime: Sep 10, 2018 8:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 11, 2018 2:22 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.ProductionOrders.Models;
using BionicInventory.Domain.ProductionOrders;
using BionicInventory.Domain.ProductionOrders.ProductionOrderLists;

namespace BionicInventory.Application.ProductionOrders.Iterfaces
{
    public interface IWorkOrdersFactory
    {
        ProductionOrder CreateNewWorkOrder(NewWorkOrderDto newOrder);

        ProductionOrder CreateUpdatedWorkOrder(UpdatedWorkOrderDto newOrder);

        IEnumerable<WorkOrderView> CreateWorkOrderViewList(IEnumerable<ProductionOrder> workOrder);
        IEnumerable<WorkOrderView> CreateWorkOrderView(ProductionOrder workOrder);
        WorkOrderView CreateWorkOrderView(ProductionOrderList workOrder);
    }
}