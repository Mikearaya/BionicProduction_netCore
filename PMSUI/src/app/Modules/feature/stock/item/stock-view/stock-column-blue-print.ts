

export const stockViewColumnBluePrint = [

  {
    key: 'itemId',
    humanReadable: 'ID',
    visable: false,
    type: 'number',
    primaryKey: true,
    allowGrouping: true,
    editable: false,
    allowFiltering: false,
    width: '20',
    isIdentity: true,
  },
  {
    key: 'itemCode',
    humanReadable: 'Code',
    visable: true,
    type: 'string',
    primaryKey: false,
    allowGrouping: false,
    allowFiltering: true,
    editable: false,
    width: '30',
    isIdentity: false,
  },
  {
    key: 'itemName',
    humanReadable: 'Description',
    visable: true,
    type: 'string',
    allowFiltering: true,
    primaryKey: false,
    allowGrouping: false,
    editable: false,
    width: '40',
    isIdentity: false,
  },
  {
    key: 'inStock',
    humanReadable: 'In Stock',
    visable: true,
    type: 'number',
    allowFiltering: true,
    primaryKey: false,
    allowGrouping: true,
    editable: false,
    width: '30',
    isIdentity: false,

  },
  {
    key: 'available',
    humanReadable: 'Available',
    visable: true,
    type: 'number',
    allowFiltering: true,
    primaryKey: false,
    allowGrouping: true,
    editable: false,
    width: '30',
    isIdentity: false,

  },
  {
    key: 'booked',
    humanReadable: 'Booked',
    visable: true,
    type: 'number',
    allowFiltering: true,
    primaryKey: false,
    allowGrouping: true,
    editable: false,
    width: '30',
    isIdentity: false
  },
  {
    key: 'totalExpected',
    humanReadable: 'Total Expected',
    visable: true,
    type: 'number',
    allowFiltering: true,
    primaryKey: false,
    allowGrouping: true,
    editable: false,
    width: '30',
    isIdentity: false
  },
  {
    key: 'expectedAvailable',
    humanReadable: 'Expected Available',
    visable: false,
    type: 'number',
    allowFiltering: true,
    primaryKey: false,
    allowGrouping: true,
    editable: false,
    width: '30',
    isIdentity: false
  },
  {
    key: 'expectedBooked',
    humanReadable: 'Expected Booked',
    visable: false,
    type: 'number',
    allowFiltering: true,
    primaryKey: false,
    allowGrouping: true,
    editable: false,
    width: '30',
    isIdentity: false
  },
  {
    key: 'averageCost',
    humanReadable: 'Avg. Cost',
    visable: false,
    type: 'number',
    allowFiltering: true,
    primaryKey: false,
    allowGrouping: true,
    editable: false,
    width: '30',
    isIdentity: false,
    format: 'C2'
  },
  {
    key: 'totalCost',
    humanReadable: 'Total Cost',
    visable: false,
    type: 'number',
    allowFiltering: true,
    primaryKey: false,
    allowGrouping: true,
    editable: false,
    width: '30',
    isIdentity: false,
    format: 'C2'
  },
  {
    key: 'minimumQuantity',
    humanReadable: 'Min. Qty',
    visable: false,
    type: 'number',
    allowFiltering: true,
    primaryKey: false,
    allowGrouping: true,
    editable: false,
    width: '30',
    isIdentity: false,
    format: '#.##'
  },
  {
    key: 'primaryUomId',
    humanReadable: 'Primary UOM Id',
    visable: false,
    type: 'number',
    allowFiltering: true,
    primaryKey: false,
    allowGrouping: true,
    editable: false,
    width: '20',
    isIdentity: false,
    format: '###'
  }
];