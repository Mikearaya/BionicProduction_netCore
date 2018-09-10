/*
 * @CreateTime: Sep 10, 2018 8:32 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2018 8:42 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Interfaces;
using BionicInventory.Domain.ProductionOrders;

namespace BionicInventory.Application.ProductionOrders.Iterfaces {
    public interface IWorkOrdersQuery {

        ProductionOrder GetWorkOrderById(uint id);

        IEnumerable<ProductionOrder> GetAllActiveWorkOrders();

        IEnumerable<ProductionOrder> GetAllWorkOrders();

        IEnumerable<ProductionOrder> GetCompletedWorkOrders();

    }
}