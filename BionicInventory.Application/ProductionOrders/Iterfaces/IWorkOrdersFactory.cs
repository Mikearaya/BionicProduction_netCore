/*
 * @CreateTime: Sep 10, 2018 8:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2018 8:33 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.ProductionOrders.Models;
using BionicInventory.Domain.ProductionOrders;

namespace BionicInventory.Application.ProductionOrders.Iterfaces
{
    public interface IWorkOrdersFactory
    {
        ProductionOrder CreateNewWorkOrder(NewWorkOrderDto newOrder);

        ProductionOrder CreateUpdatedWorkOrder(ProductionOrder previousOrder, NewWorkOrderDto newOrder);

        WorkOrderView CreateWorkOrderView(ProductionOrder workOrder);
    }
}