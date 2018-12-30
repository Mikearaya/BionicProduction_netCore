export const stockBatchColumnBluePrint = [

  {
    key: 'id',
    humanReadable: 'ID',
    visable: true,
    type: 'number',
    width: '20',
  },
  {
    key: 'itemId',
    humanReadable: 'Item Id',
    visable: false,
    type: 'number',
    width: '20',
  },
  {
    key: 'item',
    humanReadable: 'Item',
    visable: true,
    type: 'string',
    width: '70'
  },
  {
    key: 'itemGroup',
    humanReadable: 'Item Group',
    visable: true,
    type: 'string',
    width: '50'
  },
  {
    key: 'quantity',
    humanReadable: 'Quantity',
    visable: true,
    type: 'number',
    width: '35',
  },
  {
    key: 'totalBooked',
    humanReadable: 'Booked',
    visable: true,
    type: 'number',
    width: '35',
  },
  {
    key: 'unitCost',
    humanReadable: 'unit Cost',
    visable: true,
    type: 'number',
    width: '35',
    format: '##'
  },
  {
    key: 'totalCost',
    humanReadable: 'Total Cost',
    visable: true,
    type: 'number',
    width: '35',
    format: '##'
  },
  {
    key: 'status',
    humanReadable: 'Status',
    visable: true,
    type: 'string',
    width: '35',
  },
  {
    key: 'storageLocation',
    humanReadable: 'Storage',
    visable: true,
    type: 'string',
    width: '35',
  },
  {
    key: 'source',
    humanReadable: 'Source',
    visable: true,
    type: 'string',
    width: '50'
  },
  {
    key: 'storageLocationId',
    humanReadable: 'Storage Id',
    visable: false,
    type: 'number',
    width: '35',
  },
  {
    key: 'itemGroupId',
    humanReadable: 'Item Group Id',
    visable: false,
    type: 'number',
    width: '35',
  },
  {
    key: 'purchaseOrderId',
    humanReadable: 'PO Id',
    visable: false,
    type: 'number',
    width: '35',
  },
  {
    key: 'manufactureOrderId',
    humanReadable: 'MO Id',
    visable: false,
    type: 'number',
    width: '35',
  },
  {
    key: 'availableFrom',
    humanReadable: 'Available From',
    visable: true,
    type: 'datetime',
    width: '35',
    format: 'yMd'
  },
  {
    key: 'expiryDate',
    humanReadable: 'Expiry Date',
    visable: false,
    type: 'datetime',
    width: '35',
    format: 'yMd'
  },
  {
    key: 'dateAdded',
    humanReadable: 'Created',
    visable: false,
    type: 'date',
    width: '35',
    format: 'yMd'
  },
  {
    key: 'dateUpdated',
    humanReadable: 'Updated',
    visable: false,
    type: 'date',
    width: '35',
    format: 'yMd'
  }
];

