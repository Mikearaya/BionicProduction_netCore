export const writeOffColumnBluePrint = [

  {
    key: 'id',
    humanReadable: 'ID',
    visable: true,
    type: 'number',
    width: '20',
  },
  {
    key: 'item',
    humanReadable: 'Item',
    visable: true,
    type: 'string',
    width: '50',
  },
  {
    key: 'itemId',
    humanReadable: 'Item Id',
    visable: false,
    type: 'number',
    width: '20',
  },

  {
    key: 'quantity',
    humanReadable: 'Quantity',
    visable: true,
    type: 'number',
    width: '25',
  },
  {
    key: 'uom',
    humanReadable: 'UOM',
    visable: true,
    type: 'string',
    width: '25',
  },
  {
    key: 'totalCost',
    humanReadable: 'Total Cost',
    visable: true,
    type: 'number',
    width: '30',
  },
  {
    key: 'dateAdded',
    humanReadable: 'Created',
    visable: true,
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
