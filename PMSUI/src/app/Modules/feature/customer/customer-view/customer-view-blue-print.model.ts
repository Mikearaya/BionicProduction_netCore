export const customerViewColumnsBluePrint = [
  { key: 'id', humanReadable: 'ID', primaryKey: true, isIdentity: true, width: '30' },
  {
    key: 'fullName', humanReadable: 'Name', dataType: 'TextBox',
    isIdentity: false, visable: true
  },
  {
    key: 'type', humanReadable: 'Type', primaryKey: false, editable: true, dataType: 'dropdownedit',
    validationRule: { required: true }, isIdentity: false, visable: true, width: '40'
  },
  {
    key: 'tin', humanReadable: 'TIN No.', primaryKey: false, editable: true, dataType: 'TextBox',
    isIdentity: false, width: '50'
  },
  { key: 'dateAdded', humanReadable: 'Added', dataType: 'date', type: 'datetime', visable: false, width: '30', isIdentity: false },
  { key: 'dateUpdated', humanReadable: 'Updated', dataType: 'date', type: 'datetime', visable: false, width: '30', isIdentity: false }
];
