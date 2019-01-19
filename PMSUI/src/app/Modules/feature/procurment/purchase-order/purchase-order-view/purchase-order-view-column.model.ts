export const purchaseOrderColumnBluePrint = [

  {
    key: 'id',
    humanReadable: 'ID',
    visable: true,
    type: 'number',
    width: '40',
  },
  {
    key: 'vendorId',
    humanReadable: 'Vendor id',
    visable: false,
    type: 'number',
    width: '20',
  },
  {
    key: 'vendor',
    humanReadable: 'Vendor',
    visable: true,
    type: 'string',
  },
  {
    key: 'status',
    humanReadable: 'Status',
    visable: true,
    type: 'string',
    width: '50',
  },
  {
    key: 'expectedDate',
    humanReadable: 'Expected date',
    visable: true,
    type: 'date',
    width: '40',
    format: 'yMd'
  },
  {
    key: 'orderedDate',
    humanReadable: 'Ordered',
    visable: true,
    type: 'date',
    width: '40',
    format: 'yMd'
  },
  {
    key: 'shippedDate',
    humanReadable: 'Shipped date',
    visable: false,
    type: 'date',
    width: '40',
    format: 'yMd'
  },
  {
    key: 'totalCost',
    humanReadable: 'Total cost',
    visable: true,
    type: 'number',
    width: '30',
    format: '#'
  },
  {
    key: 'additionalFee',
    humanReadable: 'Additional Fee',
    visable: false,
    type: 'number',
    width: '30',
    format: '#'
  },
  {
    key: 'discount',
    humanReadable: 'Discount',
    visable: false,
    type: 'number',
    width: '30',
    format: '#'
  },
  {
    key: 'orderId',
    humanReadable: 'Order id',
    visable: false,
    type: 'string',
    width: '30',

  },
  {
    key: 'invoiceId',
    humanReadable: 'Invoice id',
    visable: false,
    type: 'string',
    width: '30',
  },
  {
    key: 'invoiceDate',
    humanReadable: 'Invoice Date',
    visable: false,
    type: 'date',
    width: '30',
    format: 'yMd'
  },
  {
    key: 'paymentDate',
    humanReadable: 'Payment Date',
    visable: false,
    type: 'date',
    width: '30',
    format: 'yMd'
  },

  {
    key: 'dateAdded',
    humanReadable: 'Create',
    visable: false,
    type: 'date',
    width: '30',
    format: 'yMd'
  },

  {
    key: 'dateUpdated',
    humanReadable: 'Updated',
    visable: false,
    type: 'date',
    width: '30',
    format: 'yMd'
  }
];
