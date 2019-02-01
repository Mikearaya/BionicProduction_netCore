

export const lowStockViewBluePrint = [

  {
    key: 'id',
    humanReadable: 'ID',
    align: 'left',
    visable: false,
    type: 'number',
    primaryKey: true,
    allowGrouping: true,
    editable: false,
    allowFiltering: false,
    width: '20px',
    isIdentity: true,
    format: ''
  },
  {
    key: 'itemCode',
    humanReadable: 'Code',
    align: 'left',
    visable: true,
    type: 'string',
    primaryKey: false,
    allowGrouping: false,
    allowFiltering: true,
    editable: false,
    width: '50',
    isIdentity: false,
    format: ''
  },
  {
    key: 'itemName',
    humanReadable: 'Item',
    align: 'left',
    visable: true,
    type: 'string',
    allowFiltering: true,
    primaryKey: false,
    allowGrouping: false,
    editable: false,
    isIdentity: false,
    format: ''
  },
  {
    key: 'inStock',
    humanReadable: 'In Stock',
    align: 'left',
    visable: true,
    type: 'number',
    allowFiltering: true,
    primaryKey: false,
    allowGrouping: true,
    editable: false,
    width: '50',
    isIdentity: false,

  },
  {
    key: 'availableQuantity',
    humanReadable: 'Available',
    align: 'left',
    visable: true,
    type: 'number',
    allowFiltering: true,
    primaryKey: false,
    allowGrouping: true,
    editable: false,
    width: '50',
    isIdentity: false,

  },
  {
    key: 'expectedAvailableQuantity',
    humanReadable: 'Expected Available',
    align: 'left',
    visable: true,
    type: 'number',
    allowFiltering: true,
    primaryKey: false,
    allowGrouping: true,
    editable: false,
    width: '50',
    isIdentity: false
  },
  {
    key: 'minimumQuantity',
    humanReadable: 'Min. Quantity',
    align: 'left',
    visable: true,
    type: 'number',
    allowFiltering: true,
    primaryKey: false,
    allowGrouping: true,
    editable: false,
    width: '50',
    isIdentity: false
  },
  {
    key: 'required',
    humanReadable: 'Required',
    align: 'left',
    visable: true,
    type: 'number',
    allowFiltering: true,
    primaryKey: false,
    allowGrouping: true,
    editable: false,
    width: '50',
    isIdentity: false
  }
];
