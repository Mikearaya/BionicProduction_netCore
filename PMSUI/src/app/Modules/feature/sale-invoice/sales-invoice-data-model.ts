
export class Invoice {
  id?: number;
  customerOrderId: number;
  tax: number;
  discount: number;
  note: string;
  dueDate: Date;
  paymentMethod: string;
  createdOn?: Date;
  invoiceItems: InvoiceItems[] = [];
  InvoicePayments: InvoicePayments[] = [];

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

export class InvoicePayments {
  id: number;
  amount: number;
  dateAdded?: Date;
  note?: string;
}

export class InvoicePaymentSummary {
  PaidAmount: number;
  TotalAmount: number;
  InvoiceNo: number;
  PreparedBy: string;
}
