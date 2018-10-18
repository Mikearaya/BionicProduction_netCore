/*
 * @CreateTime: Sep 10, 2018 8:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 18, 2018 10:19 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Interfaces;
using BionicInventory.Domain.ProductionOrders.ProductionOrderLists;

namespace BionicInventory.Application.ProductionOrders.Iterfaces {
    public interface IWorkOrdersCommand {

        ProductionOrderList CreateNewWorkOrder(ProductionOrderList newWorkOrder);
        ProductionOrderList UpdateWorkOrder(ProductionOrderList newWorkOrder);
        bool DeleteWorkOrder(ProductionOrderList deletedWorkOrder);

    }
}