/*
 * @CreateTime: Sep 12, 2018 12:48 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 12, 2018 1:08 AM
 * @Description: Modify Here, Please
 */

export const salesOrderBluePrint = [
  {
    key: 'Id',
    humanReadable: 'ID',
    type: 'number', primaryKey: true,
    allowGrouping: true, editable: false, width: '20', isIdentity: true
  },
  {
    key: 'OrderCode', humanReadable: 'CODE', primaryKey: true, type: 'string', editable: false, allowGrouping: false, dataType: 'TextBox',
    validationRule: { required: true }, isIdentity: true, width: '20', visable: false
  },
  {
    key: 'CustomerName', humanReadable: 'CUSTOMER', type: 'string', primaryKey: false,
    allowGrouping: true, editable: true, dataType: 'TextBox',
    isIdentity: false, width: '30'
  },
  {
    key: 'ItemCode', humanReadable: 'PRODUCT', primaryKey: false, type: 'string',
    editable: true, allowGrouping: true, dataType: 'TextBox', validationRule: { required: true }, isIdentity: false, width: '40'
  },
  {
    key: 'Quantity', humanReadable: 'Quantity', primaryKey: false, type: 'number', allowGrouping: true, editable: true, dataType: 'TextBox',
    isIdentity: false, width: '25'
  },
  {
    key: 'UnitPrice', humanReadable: 'Unit Price', primaryKey: false, allowGrouping: true, type: 'number',
    editable: true, dataType: 'TextBox',
    isIdentity: false, width: '25'
  },
  {
    key: 'totalPrice', humanReadable: 'Sub Total', primaryKey: false, allowGrouping: true, type: 'number',
    editable: true, dataType: 'TextBox',
    isIdentity: false, width: '30'
  },
  {
    key: 'Status', humanReadable: 'STATUS', primaryKey: false, allowGrouping: true, type: 'string',
    editable: true, dataType: 'TextBox',
    isIdentity: false, width: '30'
  },
  {
    key: 'remainingPayment', humanReadable: 'Remaining', primaryKey: false, allowGrouping: true, type: 'number',
    editable: true, dataType: 'TextBox', visable: false,
    isIdentity: false, width: '30'
  },
  {
    key: 'PaymentMethod', humanReadable: 'Payment Mathod', primaryKey: false, allowGrouping: true, type: 'string',
    editable: true, dataType: 'TextBox',
    isIdentity: false, width: '30'
  },
  {
    key: 'OrderedOn', humanReadable: 'Order Date', allowGrouping: true, format: 'yMd',
    primaryKey: false, editable: true, type: 'date', dataType: 'datetime',
    isIdentity: false, width: '30', visable: false
  },
  {
    key: 'DueDate', humanReadable: 'Due Date', allowGrouping: true, format: 'yMd',
    primaryKey: false, editable: true, type: 'date', dataType: 'datePickeredit',
    isIdentity: false, width: '30'
  },
  {
    key: 'CreatedBy', humanReadable: 'Ordered By', type: 'string',
    primaryKey: false, allowGrouping: true, editable: true, dataType: 'TextBox',
    isIdentity: false, width: '40', visable: false
  }
];
