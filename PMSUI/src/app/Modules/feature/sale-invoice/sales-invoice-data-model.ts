
export class Invoice {
  id?: number;
  customerOrderId: number;
  tax: number;
  discount: number;
  note: string;
  dueDate: Date;
  invoiceItems: InvoiceItems[] = [];

}

export class InvoiceItems {
  id?: number;
  customerOrderItemId: number;
  itemId: number;
  quantity: number;
  unitPrice: number;
  discount: number;
  note: string;

}
