export class InvoiceSummary {
  Id: number;
  InvoiceType: string;
  CreatedOn: Date;
  Status: string;
  TotalAmount: number;
  PaidAmount: number;
  Duedate: Date;
}


export class InvoiceDetail {
  Id: number;
  CustomerId: string;
  CustomerName: string;
  InvoiceType: string;
  CreatedOn: Date;
  DateAdded: Date;
  Status: string;
  TotalAmount: number;
  TotalAfterTax: number;
  PaidAmount: number;
  Duedate: Date;
}
