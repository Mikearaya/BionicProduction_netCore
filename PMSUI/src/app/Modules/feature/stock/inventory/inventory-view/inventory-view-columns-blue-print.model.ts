export const inventoryColumnBluePrint = [

  {
    key: 'itemId',
    humanReadable: 'ID',
    visable: false,
    type: 'number',
    width: '20',
  },
  {
    key: 'itemCode',
    humanReadable: 'Item Code',
    visable: true,
    type: 'string',
    width: '70',
  },
  {
    key: 'item',
    humanReadable: 'Item',
    visable: true,
    type: 'string',
  },
  {
    key: 'itemGroup',
    humanReadable: 'Item Group',
    visable: true,
    type: 'string',
    width: '100',
  },
  {
    key: 'averageUnitCost',
    humanReadable: 'Avg Cost',
    visable: true,
    type: 'number',
    width: '50',
  },
  {
    key: 'totalCost',
    humanReadable: 'Cost',
    visable: true,
    type: 'number',
    width: '50',
  },
  {
    key: 'dateAdded',
    humanReadable: 'Created',
    visable: false,
    type: 'date',
    width: '50',
    format: 'yMd'
  },
  {
    key: 'dateUpdated',
    humanReadable: 'Last Updated',
    visable: false,
    type: 'date',
    width: '50',
    format: 'yMd'
  }
];
