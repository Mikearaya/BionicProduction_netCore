export const purchaseRecievingColumnBluePrint = [

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
    key: 'expectedDate',
    humanReadable: 'Expected date',
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
