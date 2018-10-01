/*
 * @CreateTime: Oct 1, 2018 9:47 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 1, 2018 9:52 PM
 * @Description: Modify Here, Please
 */

export const pendingOrdersBluePrint = [
  {
    key: 'purchaseOrderId',
    humanReadable: 'ID',
    type: 'number', primaryKey: true,
    visable: false,
    allowGrouping: false, editable: false, width: '30', isIdentity: true
  },
  {
    key: 'purchaseOrderItemId', humanReadable: 'ID', primaryKey: true, type: 'number',
    editable: false, allowGrouping: false, dataType: 'TextBox',
    isIdentity: true, width: '15'
  },
  {
    key: 'client', humanReadable: 'Customer', type: 'string', primaryKey: false, allowGrouping: true, editable: true, dataType: 'TextBox',
    isIdentity: false, width: '25'
  },
  {
    key: 'description', humanReadable: 'Description', primaryKey: false, type: 'string',
    editable: true, allowGrouping: true, dataType: 'TextBox', isIdentity: false, width: '40'
  },
  {
    key: 'product', humanReadable: 'Product', primaryKey: false, type: 'string', allowGrouping: true, editable: true, dataType: 'TextBox',
    isIdentity: false, width: '25'
  },
  {
    key: 'quantity', humanReadable: 'Quantity', primaryKey: false, allowGrouping: true, type: 'number',
    editable: true, dataType: 'numeric',
    isIdentity: false, width: '20'
  },
  {
    key: 'orderDate',  humanReadable: 'Ordered', allowGrouping: true, format: 'yMd',
    primaryKey: false, editable: true, visable: false, type: 'date', dataType: 'datePickeredit',
    isIdentity: false, width: '30'
  },
  {
    key: 'dueDate', humanReadable: 'Due', allowGrouping: true, format: 'yMd',
    primaryKey: false, editable: true, type: 'date', dataType: 'datePickeredit',
    isIdentity: false, width: '30'
  },
  {
    key: 'orderedBy', humanReadable: 'Requested By', type: 'string',
    primaryKey: false, allowGrouping: true, editable: true, dataType: 'TextBox',
    isIdentity: false, width: '30'
  }
];
