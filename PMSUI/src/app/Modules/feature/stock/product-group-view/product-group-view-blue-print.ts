

export const productGroupColumnBluePrint = [

  {
    key: 'id',
    humanReadable: 'ID',
    visable: false,
    type: 'number',

  },
  {
    key: 'groupName',
    humanReadable: 'Group Name',
    visable: true,
    type: 'string',

  },
  {
    key: 'description',
    humanReadable: 'Description',
    visable: true,
    type: 'string',
    width: '50',
  },
  {
    key: 'parentGroup',
    humanReadable: 'Parent',
    visable: true,
    type: 'string',
    width: '50',
  },
  {
    key: 'dateAdded',
    humanReadable: 'Created',
    visable: true,
    type: 'datetime',
    width: '50',
  },
  {
    key: 'dateUpdated',
    humanReadable: 'Updated',
    visable: false,
    type: 'string',
    width: '30',
  }


];
