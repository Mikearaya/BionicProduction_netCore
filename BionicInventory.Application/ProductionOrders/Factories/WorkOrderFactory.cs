/*
 * @CreateTime: Sep 10, 2018 8:32 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2018 8:32 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.ProductionOrders.Iterfaces;
using BionicInventory.Application.ProductionOrders.Models;
using BionicInventory.Domain.ProductionOrders;

namespace BionicInventory.Application.ProductionOrders.Factories
{
    public class WorkOrderFactory : IWorkOrdersFactory
    {
        public ProductionOrder CreateNewWorkOrder(NewWorkOrderDto newOrder)
        {
            throw new System.NotImplementedException();
        }

        public ProductionOrder CreateUpdatedWorkOrder(ProductionOrder previousOrder, NewWorkOrderDto newOrder)
        {
            throw new System.NotImplementedException();
        }

        public WorkOrderView CreateWorkOrderView(ProductionOrder workOrder)
        {
            throw new System.NotImplementedException();
        }
    }
}