

export const customerOrderDetailBluePrint = [
    {key: 'id',
    humanReadable: 'ID',
    visible: false
    },
    {key: 'quantity',
    humanReadable: 'Quantity'
    },
    {key: 'productCode',
    humanReadable: 'SKU'
    },
    {key: 'productName',
    humanReadable: 'productName',
    },
    {key: 'unitPrice',
    humanReadable: 'Unit Price',
    format: 'C2'
    },
    {key: 'totalPrice',
    humanReadable: 'Sub Total',
    format: 'C2'
    },
    {key: 'dueDate',
    humanReadable: 'Delivery Date',
    },
    {key: 'totalCost',
    humanReadable: 'Cost',
    format: 'C2'
    },
    {key: 'profit',
    humanReadable: 'ID',
    format: 'C2',
    },
    {key: 'status',
    humanReadable: 'Status',
    },
    {key: 'manufacturingOrderId',
    humanReadable: 'Manufacturing Order',
    },
    {key: 'shipped',
    humanReadable: 'shipped', visible : false
    }


];


export const invoiceColumnBluePrint =  [
  {key: 'id',
  humanReadable: 'Number',
  isIdentity: true,
  isPrimaryKey: true
  },
  {
    key: 'type',
    humanReadable: 'Type'
  },
  {
    key: 'dateCreated',
    humanReadable: 'Created',
    format: 'yMd'
  },
  {key: 'status',
    humanReadable: 'Status'
  },
  {
    key: 'totalAmount',
    humanReadable: 'Total',
    format: 'C2'
  },
  {
    key: 'paidAmount',
    humanReadable: 'Paid',
    format: 'C2'
  }
];

export const shipmentColumnBluePrint = [
  {key: 'id',
humanReadable: 'Number'},
{key: 'dateCreated',
humanReadable: 'Created',
format: 'yMd'},
{key: 'status',
humanReadable: 'Status'}
];

