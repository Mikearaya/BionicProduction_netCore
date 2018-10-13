


using System.Collections.Generic;

namespace BionicInventory.Application.SalesOrders.Models {

    public class CustomerOrderDetailView : CustomerOrdersView {

       public  List<CustomerOrderItemsView> orderItems {get; set;} = new List<CustomerOrderItemsView>();
    }
}