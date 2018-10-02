export const productsViewBluePrint = [
  { key: 'id', humanReadable: 'ID', primaryKey: true, editable: false, isIdentity : true, width: '20px' },
  {
    key: 'code', humanReadable: 'Code', primaryKey: false, editable: true, dataType: 'TextBox',
    validationRule: { required: true }, isIdentity : false, width: '30px'
  },
  {
    key: 'name', humanReadable: 'Name', primaryKey: false, editable: true, dataType: 'TextBox',
    validationRule: { required: true }, isIdentity : false, width: '30px'
  },
  {
    key: 'discription', humanReadable: 'Discription', primaryKey: false, editable: true, dataType: 'TextBox',
    isIdentity : false, width: '50px'
  },
  {
    key: 'weight', humanReadable: 'Weight', primaryKey: false, editable: true, dataType: 'numericedit',
    validationRule: { required: true }, isIdentity : false, width: '30px'
  },
  {
    key: 'unit', humanReadable: 'Unit.', primaryKey: false, editable: true, dataType: 'textbox',
    validationRule: { required: true }, isIdentity : false, width: '30px'
  },
  {
    key: 'minimumQuantity', humanReadable: 'Min Qty.', primaryKey: false, editable: true, dataType: 'numericedit',
    validationRule: { required: true }, isIdentity : false, width: '30px'
  },
  { key: 'unitCost', humanReadable: 'Unit Cost', primaryKey: false, editable: true, dataType: 'numeric',
   isIdentity : false, width: '30px' }
];
