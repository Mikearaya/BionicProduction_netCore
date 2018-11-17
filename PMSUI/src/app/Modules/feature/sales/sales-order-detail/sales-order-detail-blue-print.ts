

export const customerOrderDetailBluePrint = [
  {
    key: 'id',
    humanReadable: 'ID',
    visible: false
  },
  {
    key: 'quantity',
    humanReadable: 'Quantity'
  },
  {
    key: 'productName',
    humanReadable: 'Product',
  },
  {
    key: 'unitPrice',
    humanReadable: 'Unit Price',
    format: 'C2'
  },
  {
    key: 'totalPrice',
    humanReadable: 'Sub Total',
    format: 'C2'
  },
  {
    key: 'dueDate',
    humanReadable: 'Delivery Date',
  },
  {
    key: 'totalCost',
    humanReadable: 'Cost',
    format: 'C2'
  },
  {
    key: 'profit',
    humanReadable: 'Profit',
    format: 'C2',
  },
  {
    key: 'manufacturingOrderId',
    humanReadable: 'Manufacturing Order',
  },
  {
    key: 'shipped',
    humanReadable: 'shipped', visible: false
  }


];


export const invoiceColumnBluePrint = [
  {
    key: 'Id',
    humanReadable: 'Number',
    isIdentity: true,
    isPrimaryKey: true,
    width: 20
  },
  {
    key: 'InvoiceType',
    humanReadable: 'Type',
    width: 25
  },
  {
    key: 'CreatedOn',
    humanReadable: 'Created',
    format: 'yMd',
    width: 30
  },
  {
    key: 'Status',
    humanReadable: 'Status',
    width: 20
  },
  {
    key: 'TotalAmount',
    humanReadable: 'Total',
    format: 'C2',
    width: 20
  },
  {
    key: 'PaidAmount',
    humanReadable: 'Paid',
    format: 'C2',
    width: 20
  },
  {
    key: 'DueDate',
    humanReadable: 'Due Date',
    format: 'yMd',
    width: 30
  }

];

export const shipmentColumnBluePrint = [
  {
    key: 'id',
    humanReadable: 'Number',
    type: 'number',
    width: '10'
  },
  {
    key: 'dateAdded',
    humanReadable: 'Created',
    format: 'yMd',
    type: 'date',
    width: '20'
  },
  {
    key: 'deliveryDate',
    humanReadable: 'Delivery Date',
    format: 'yMd',
    type: 'date',
    width: '20'
  }
];

