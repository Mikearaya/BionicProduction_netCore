
export class CustomerOrderDetailView {
  id: string;
  customerName: string;
  createdBy: string;
  description: string;
  totalQuantity: number;
  totalPrice: number;
  totalCost: number;
  totalProducts: number;
  paymentMethod: string;
  status: string;
  duedate: Date;
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
