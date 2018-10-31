/*
 * @CreateTime: Oct 23, 2018 8:28 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 23, 2018 8:28 PM
 * @Description: Modify Here, Please 
 */



using System.Collections.Generic;

namespace BionicInventory.Application.SalesOrders.Models {

    public class CustomerOrderDetailView : CustomerOrdersView {

    public  List<CustomerOrderItemsView> orderItems {get; set;} = new List<CustomerOrderItemsView>();
    }
}