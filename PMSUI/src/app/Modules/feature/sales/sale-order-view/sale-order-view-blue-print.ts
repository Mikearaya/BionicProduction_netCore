/*
 * @CreateTime: Sep 12, 2018 12:48 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 13, 2018 9:32 PM
 * @Description: Modify Here, Please
 */

export const salesOrderBluePrint = [
  {
    key: 'id',
    humanReadable: 'ID',
    type: 'number', primaryKey: true,
    allowGrouping: true, editable: false, width: '20', isIdentity: true
  },
  {
    key: 'customerName', humanReadable: 'Customer', type: 'string', primaryKey: false,
    allowGrouping: true, editable: true, dataType: 'TextBox',
    isIdentity: false, width: '35'
  },
  {
    key: 'createdBy', humanReadable: 'Ordered By', type: 'string',
    primaryKey: false, allowGrouping: true, editable: true, dataType: 'TextBox',
    isIdentity: false, width: '40', visable: false
  },

  {
    key: 'description', humanReadable: 'Description', primaryKey: false, type: 'string',
    editable: true, allowGrouping: true, dataType: 'TextBox', isIdentity: false, width: '40', visable : false,
  },
  {
    key: 'totalQuantity', humanReadable: 'Quantity', primaryKey: false, type: 'number',
    allowGrouping: true, editable: true, dataType: 'TextBox',
    isIdentity: false, width: '30'
  },
  {
    key: 'totalProducts', humanReadable: '# Items', primaryKey: false, type: 'number',
    allowGrouping: true, editable: true, dataType: 'TextBox',
    isIdentity: false, width: '28'
  },
  {
    key: 'totalCost', humanReadable: 'Cost', primaryKey: false, allowGrouping: true, type: 'number',
    editable: true, dataType: 'TextBox', format: 'C2',
    isIdentity: false, width: '25'
  },
  {
    key: 'totalPrice', humanReadable: 'Price', primaryKey: false, allowGrouping: true, type: 'number',
    editable: true, dataType: 'TextBox', format: 'C2',
    isIdentity: false, width: '25'
  },
  {
    key: 'status', humanReadable: 'Status', primaryKey: false, allowGrouping: true, type: 'string',
    editable: true, dataType: 'TextBox',
    isIdentity: false, width: '30'
  },
  {
    key: 'dateAdded', humanReadable: 'Created', allowGrouping: true, format: 'yMd',
    primaryKey: false, editable: true, type: 'date', dataType: 'datetime',
    isIdentity: false, width: '30'
  },
  {
    key: 'dateUpdated', humanReadable: 'Updated', allowGrouping: true,
    primaryKey: false, editable: true, type: 'date', dataType: 'datePickeredit',
    isIdentity: false, width: '30', visable: false
  }
];
