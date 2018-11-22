
export class CustomerOrderDetailView {
  id: string;
  customerName: string;
  createdBy: string;
  description: string;
  createdOn: Date;
  totalQuantity: number;
  totalPrice: number;
  totalCost: number;
  totalProducts: number;
  paymentMethod: string;
  deliveryDate: Date;
  status: String = '';
  dueDate: Date;
  dateAdded: Date;
  dateUpdated: Date;
  orderItems: CustomerOrderItemsView[] = [];

}

export class CustomerOrderItemsView {
  id: number;
  quantity: number;
  productId: number;
  productCode: string;
  productName: string;
  unitPrice: number;
  totalPrice: number;
  unitCost: number;
  totalCost: number;
  profit: number;
  status: string;
  deliveryDate: Date;
  totalShipped: number;
  manufacturingOrderId: string;
  dateAdded: Date;
  dateUpdated: Date;
  dueDate: Date;

}

export class SalesOrder {
  Id?: number;
  clientId: number;
  createdBy: number;
  description: string;
  deliveryDate?: Date;
  createdOn?: Date;
  status: string;
  PurchaseOrderDetail: SalesOrderDetail[] = [];


  }

  class SalesOrderDetail {
    itemId: number;
    unitPrice: number;
    quantity: number;
    dueDate: number;
  }


  export class SalesOrderView {
    Id: number;
    CustomerName: string;
    OrderCode: string;
    CreatedBy: string;
    ItemCode: string;
    Quantity: number;
    UnitPrice: number;

    remainingPayment: number;
    paidAmount: number;
    totalAmount: number;
    OrderedOn: string;
    DueDate: string;
  }

