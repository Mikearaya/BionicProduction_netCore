export const storageLocationColumnBluePrint = [

  {
    key: 'id',
    humanReadable: 'Id',
    visable: true,
    type: 'number',
    width: 30,

  },
  {
    key: 'name',
    humanReadable: 'Name',
    visable: true,
    type: 'string',

  },
  {
    key: 'dateAdded',
    humanReadable: 'Created',
    visable: true,
    type: 'datetime',
    format: 'yMd',
    width: '50'

  },
  {
    key: 'dateUpdated',
    humanReadable: 'Updated',
    visable: false,
    type: 'datetime',
    format: 'yMd',
    width: '50'

  }
];
