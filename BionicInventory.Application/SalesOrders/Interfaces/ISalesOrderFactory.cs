/*
 * @CreateTime: Nov 4, 2018 9:16 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 4, 2018 9:16 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Application.SalesOrders.Models;
using BionicInventory.Domain.Customers;
using BionicInventory.Domain.Employees;
using BionicInventory.Domain.Items;
using BionicInventory.Domain.PurchaseOrders;

namespace BionicInventory.Application.SalesOrders.Interfaces {
    public interface ISalesOrderFactory {
        PurchaseOrder CreateNewSaleOrder (NewSalesOrderDto customerOrder);
        IEnumerable<PurchaseOrder> CreateUpdatesSaleOrder (IEnumerable<UpdatedSalesOrderDto> newOrder);
        SalesOrderView CreateSaleOrderView (PurchaseOrder newOrder);
      

        uint ExtractId(string id);
    }
}