export const bomColumBluePrint = [
  {
    key: 'id',
    humanReadable: 'ID',
    visable: true,
    type: 'number',
    width: '20'

  },
  {
    key: 'name',
    humanReadable: 'Name',
    visable: true,
    type: 'string',

  },
  {
    key: 'itemId',
    humanReadable: 'Item Id',
    visable: false,
    type: 'number',
    width: '20'
  },
  {
    key: 'item',
    humanReadable: 'Item',
    visable: true,
    type: 'string',
    width: '70'
  }
];

export const bomItemColumnBluePrint = [
  {
    key: 'id',
    humanReadable: 'Id',
    visable: true,
    type: 'number',
  },
  {
    key: 'bomId',
    humanReadable: 'Bom',
    visable: false,
    type: 'number',
  },
  {
    key: 'itemId',
    humanReadable: 'Item Id',
    visable: false,
    type: 'number',
    width: '30'
  },
  {
    key: 'item',
    humanReadable: 'Item',
    visable: true,
    type: 'string',
    width: '30'
  }, {
    key: 'quantity',
    humanReadable: 'Quantity',
    visable: true,
    type: 'string',
    width: '30'

  },
  {
    key: 'uomId',
    humanReadable: 'UOM',
    visable: true,
    type: 'string',
    width: '20'
  },

];
