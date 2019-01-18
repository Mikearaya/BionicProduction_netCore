export const vendorColumnBluePrint = [

  {
    key: 'id',
    humanReadable: 'ID',
    visable: false,
    type: 'number',
    width: '20',
  },
  {
    key: 'name',
    humanReadable: 'Vendor Name',
    visable: true,
    type: 'string',
  },
  {
    key: 'tinNumber',
    humanReadable: 'TIN',
    visable: true,
    type: 'string',
    width: '50'
  },
  {
    key: 'phoneNumber',
    humanReadable: 'Phone',
    visable: true,
    type: 'string',
    width: '50'
  },
  {
    key: 'leadTime',
    humanReadable: 'Lead Time',
    visable: true,
    type: 'number',
    format: '##',
    width: '40'
  },
  {
    key: 'paymentPeriod',
    humanReadable: 'Payment Period',
    visable: true,
    type: 'number',
    format: '##',
    width: '40'
  },
  {
    key: 'dateAdded',
    humanReadable: 'Added',
    visable: false,
    type: 'date',
    format: 'dYm',
    width: '35'
  },
  {
    key: 'dateUpdated',
    humanReadable: 'Updated',
    visable: false,
    type: 'date',
    format: 'dYm',
    width: '35'
  }
];
