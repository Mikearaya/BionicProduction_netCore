/*
 * @CreateTime: Sep 10, 2018 8:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2018 11:03 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.ProductionOrders.Models;
using BionicInventory.Domain.ProductionOrders;

namespace BionicInventory.Application.ProductionOrders.Iterfaces
{
    public interface IWorkOrdersFactory
    {
        ProductionOrder CreateNewWorkOrder(NewWorkOrderDto newOrder);

        ProductionOrder CreateUpdatedWorkOrder(ProductionOrder previousOrder, UpdatedWorkOrderDto newOrder);

        IEnumerable<WorkOrderView> CreateWorkOrderViewList(IEnumerable<ProductionOrder> workOrder);
        IEnumerable<WorkOrderView> CreateWorkOrderView(ProductionOrder workOrder);
    }
}