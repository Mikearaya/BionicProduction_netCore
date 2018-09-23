/*
 * @CreateTime: Sep 12, 2018 12:48 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 12, 2018 1:08 AM
 * @Description: Modify Here, Please
 */

export const workOrderBluePrint = [
  {
    key: 'orderId',
    humanReadable: 'Order ID',
    type: 'number', primaryKey: true,
    allowGrouping: true, editable: false, width: '30', isIdentity: true
  },
  {
    key: 'description', humanReadable: 'Description', primaryKey: false, type: 'string',
    editable: true, allowGrouping: true, dataType: 'TextBox',   validationRule: { required: true }, isIdentity: false, width: '40'
  },
  {
    key: 'id', humanReadable: 'ID', primaryKey: true, type: 'number', editable: false, allowGrouping: false, dataType: 'TextBox',
    validationRule: { required: true }, isIdentity: true, width: '20'
  },
  {
    key: 'product', humanReadable: 'Product', primaryKey: false, type: 'string', allowGrouping: true, editable: true, dataType: 'TextBox',
    isIdentity: false, width: '40'
  },
  {
    key: 'quantity', humanReadable: 'Total', primaryKey: false, allowGrouping: true, type: 'number',
    editable: true, dataType: 'TextBox',
    isIdentity: false, width: '30'
  },
  {
    key: 'completed', humanReadable: 'Completed', type: 'number', primaryKey: false, format: '',
    allowGrouping: true, editable: true, dataType: 'numericedit',
    validationRule: { required: true }, isIdentity: false, width: '40'
  },
  {
    key: 'remaining', humanReadable: 'Remaining', type: 'number', primaryKey: false, allowGrouping: true, format: '',
    editable: true, dataType: 'numericedit',
    validationRule: { required: true }, isIdentity: false, width: '40'
  },
  {
    key: 'orderDate', humanReadable: 'Order Date', allowGrouping: true, format: 'yMd',
    primaryKey: false, editable: true, type: 'date', dataType: 'datetime',
    isIdentity: false, width: '40'
  },
  {
    key: 'dueDate', humanReadable: 'Due Date', allowGrouping: true, format: 'yMd',
    primaryKey: false, editable: true, type: 'date', dataType: 'datePickeredit',
    isIdentity: false, width: '40'
  },
  {
    key: 'orderedBy', humanReadable: 'Ordered By', type: 'string',
    primaryKey: false, allowGrouping: true, editable: true, dataType: 'TextBox',
    isIdentity: false, width: '40'
  },
  {
    key: 'status', humanReadable: 'Status', type: 'boolean', primaryKey: false, allowGrouping: true, editable: true, dataType: 'TextBox',
    isIdentity: false, width: '30'
  }
];
