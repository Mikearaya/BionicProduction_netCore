/*
 * @CreateTime: Oct 31, 2018 9:51 PM
 * @Author: undefined
 * @Contact: undefined
 * @Last Modified By: undefined
 * @Last Modified Time: Oct 31, 2018 9:51 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Interfaces;
using BionicInventory.Domain.CustomerOrders;

namespace BionicInventory.Application.SalesOrders.Interfaces {
    public interface ISalesOrderCommand {

        CustomerOrder CreateSalesOrder (CustomerOrder orders);

        bool UpdateSalesOrder (CustomerOrder orders);

        bool DeleteSalesOrders (CustomerOrder order);

    }
}