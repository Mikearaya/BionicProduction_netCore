/*
 * @CreateTime: Sep 12, 2018 12:48 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 12, 2018 12:48 AM
 * @Description: Modify Here, Please
 */

export const workOrderBluePrint = [
  {
    key: 'id', humanReadable: 'Order ID', type: 'number', primaryKey: true,
    allowGrouping: true, editable: false, width: '50', isIdentity: true
  },
  {
    key: 'description', humanReadable: 'Description', primaryKey: false, type: 'string',
    editable: true, allowGrouping: true, dataType: 'TextBox',
    validationRule: { required: true }, isIdentity: false, width: '100'
  },
  {
    key: 'orderId', humanReadable: 'ID', primaryKey: false, type: 'number', editable: false, allowGrouping: false, dataType: 'TextBox',
    validationRule: { required: true }, isIdentity: false, width: '50'
  },
  {
    key: 'product', humanReadable: 'Product', primaryKey: false, type: 'string', allowGrouping: true, editable: true, dataType: 'TextBox',
    isIdentity: false, width: '70'
  },
  {
    key: 'quantity', humanReadable: 'Quantity', primaryKey: false, allowGrouping: true, type: 'number',
    editable: true, dataType: 'TextBox',
    isIdentity: false, width: '70'
  },
  {
    key: 'costPerItem', humanReadable: 'Unit Cost', type: 'number', primaryKey: false, format: 'C2',
    allowGrouping: true, editable: true, dataType: 'numericedit',
    validationRule: { required: true }, isIdentity: false, width: '70'
  },
  {
    key: 'orderDate', humanReadable: 'Ordered', type: 'date', primaryKey: false, allowGrouping: true, format: 'yMMMd',
    editable: true, dataType: 'datetime',
    validationRule: { required: true }, isIdentity: false, width: '100'
  },
  {
    key: 'dueDate', humanReadable: 'Due Date', allowGrouping: true, format: 'yMMMEd',
    primaryKey: false, editable: true, type: 'date', dataType: 'datetime',
    isIdentity: false, width: '100'
  },
  {
    key: 'orderedBy', humanReadable: 'Ordered By', type: 'string',
    primaryKey: false, allowGrouping: true, editable: true, dataType: 'TextBox',
    isIdentity: false, width: '70'
  },
  {
    key: 'status', humanReadable: 'Status', type: 'boolean', primaryKey: false, allowGrouping: true, editable: true, dataType: 'TextBox',
    isIdentity: false, width: '50'
  }
];
