/*
 * @CreateTime: Sep 10, 2018 8:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2018 8:42 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Interfaces;
using BionicInventory.Domain.ProductionOrders;

namespace BionicInventory.Application.ProductionOrders.Iterfaces {
    public interface IWorkOrdersCommand {

        ProductionOrder CreateNewWorkOrder(ProductionOrder newWorkOrder);
        ProductionOrder UpdateWorkOrder(ProductionOrder newWorkOrder);
        bool DeleteWorkOrderItemById(uint id);
        bool DeleteWorkOrderById(uint id);

    }
}