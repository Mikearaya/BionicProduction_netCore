

export const routingColumnBluePrint = [

  {
    key: 'id',
    humanReadable: 'ID',
    visable: true,
    type: 'number',
    width: '30'

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
    width: '30'

  },
  {
    key: 'itemName',
    humanReadable: 'Item',
    visable: true,
    type: 'string',
    width: '70'

  },
  {
    key: 'itemGroupId',
    humanReadable: 'Item Group Id',
    visable: false,
    type: 'number',
    width: '30'

  },
  {
    key: 'itemGroupName',
    humanReadable: 'Item Group',
    visable: false,
    type: 'string',
    width: '70'

  },
  {
    key: 'approximateCost',
    humanReadable: 'Approximate Cost',
    visable: true,
    type: 'number',
    width: '50'

  },
  {
    key: 'approximateTime',
    humanReadable: 'Approximate Time',
    visable: true,
    type: 'number',
    width: '50'

  },
  {
    key: 'dateAdded',
    humanReadable: 'Added',
    visable: false,
    type: 'date',
    width: '50',
    format: 'yMd'

  },
  {
    key: 'dateUpdated',
    humanReadable: 'Update',
    visable: false,
    type: 'date',
    width: '50',
    format: 'yMd'

  }
];
