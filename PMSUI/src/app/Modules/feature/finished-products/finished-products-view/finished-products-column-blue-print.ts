

export const finishedProductsBluePrint = [

  {
    key: 'product',
    humanReadable: 'Product',
    align: 'left',
    visable: true,
    type: 'string',
    primaryKey: false,
    allowGrouping: true,
    editable: false,
    allowFiltering: true,
    width: '50',
    isIdentity: false,
    format: ''
  },
  {
    key: 'quantity',
    humanReadable: 'Quantity',
    align: 'left',
    visable: true,
    type: 'number',
    primaryKey: false,
    allowGrouping: true,
    allowFiltering: true,
    editable: false,
    width: '50',
    isIdentity: false,
    format: ''
  },
  {
    key: 'cost',
    humanReadable: 'Total Cost',
    align: 'left',
    visable: true,
    type: 'number',
    allowFiltering: true,
    primaryKey: false,
    allowGrouping: true,
    editable: false,
    width: '50',
    isIdentity: false,
    format: 'C2'
  }
];

