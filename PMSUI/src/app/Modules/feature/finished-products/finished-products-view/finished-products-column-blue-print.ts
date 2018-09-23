

export const finishedProductsBluePrint = [
  {
    key: 'id', humanReadable: 'ID', visable: false,  type: 'number', primaryKey: true,
    allowGrouping: true, editable: false, width: '30', isIdentity: true, format: ''
  },
  {
    key: 'orderId', humanReadable: 'Order ID', visable: true,  type: 'string', primaryKey: false,
    allowGrouping: true, editable: false, width: '50', isIdentity: false, format: ''
  },
  {
    key: 'submitedBy', humanReadable: 'Submiter ID', visable: false,  type: 'number', primaryKey: false,
    allowGrouping: true, editable: false, width: '50', isIdentity: false, format: ''
  },
  {
    key: 'recievedBy', humanReadable: 'Reciever ID', visable: false,  type: 'number', primaryKey: false,
    allowGrouping: true, editable: false, width: '50', isIdentity: false, format: ''
  },
  {
    key: 'quantity', humanReadable: 'Quantity', visable: true,  type: 'number', primaryKey: false,
    allowGrouping: true, editable: false, width: '50', isIdentity: false, format: ''
  },
  {
    key: 'product', humanReadable: 'Product', visable: true,  type: 'string', primaryKey: false,
    allowGrouping: true, editable: false, width: '50', isIdentity: false, format: ''
  },
  {
    key: 'cost', humanReadable: 'Cost', visable: true,  type: 'number', primaryKey: false,
    allowGrouping: true, editable: false, width: '50', isIdentity: false, format: ''
  },
  {
    key: 'submitter', humanReadable: 'Submited By', visable: true,  type: 'string', primaryKey: false,
    allowGrouping: true, editable: false, width: '70', isIdentity: false, format: ''
  },
  {
    key: 'reciever', humanReadable: 'Recieved By', visable: true,  type: 'string', primaryKey: false,
    allowGrouping: true, editable: false, width: '70', isIdentity: false, format: ''
  },
  {
    key: 'dateAdded', humanReadable: 'Date Added', visable: true,  type: 'date', primaryKey: false,
    allowGrouping: true, editable: false, width: '50', isIdentity: false, format: 'yMd'
  },
  {
    key: 'dateUpdated', humanReadable: 'Date Updated', visable: false,  type: 'date', primaryKey: false,
    allowGrouping: true, editable: false, width: '70', isIdentity: false, format: 'yMd'
  }
];

