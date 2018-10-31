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
using BionicInventory.Domain.PurchaseOrders;

namespace BionicInventory.Application.SalesOrders.Interfaces {
    public interface ISalesOrderCommand {

        PurchaseOrder CreateSalesOrder(PurchaseOrder orders);

        bool UpdateSalesOrder(IEnumerable<PurchaseOrder> orders);

        bool DeleteSalesOrders(PurchaseOrder order);

    }
}