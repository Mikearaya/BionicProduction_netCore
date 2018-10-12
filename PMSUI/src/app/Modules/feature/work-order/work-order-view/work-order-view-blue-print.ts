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
    allowGrouping: true, editable: false, width: '20', visable: false, isIdentity: true
  },
  {
    key: 'id', humanReadable: 'ID', primaryKey: true, type: 'number', editable: false, allowGrouping: false, dataType: 'TextBox',
    validationRule: { required: true }, isIdentity: true, width: '20'
  }  ,
  {
    key: 'customer', humanReadable: 'Customer', type: 'string', primaryKey: false, allowGrouping: true, editable: true, dataType: 'TextBox',
    isIdentity: false, width: '28'
  },
  {
    key: 'description', humanReadable: 'Description', primaryKey: false, type: 'string', visable: false,
    editable: true, allowGrouping: true, dataType: 'TextBox', validationRule: { required: true }, isIdentity: false, width: '40'
  },
  {
    key: 'productName', humanReadable: 'Product', primaryKey: false, type: 'string',
    allowGrouping: true, editable: true, dataType: 'TextBox',
    isIdentity: false, width: '25'
  },
  {
    key: 'quantity', humanReadable: 'Total', primaryKey: false, allowGrouping: true, type: 'number',
    editable: true, dataType: 'TextBox',
    isIdentity: false, width: '25'
  },
  {
    key: 'cost', humanReadable: 'Total Cost', primaryKey: false, allowGrouping: true, type: 'number',
    editable: true, dataType: 'TextBox', format : 'C2',
    isIdentity: false, width: '28'
  },
  {
    key: 'orderDate', humanReadable: 'Order Date', visable: true, allowGrouping: true, format: 'yMd',
    primaryKey: false, editable: true, type: 'date', dataType: 'datetime',
    isIdentity: false, width: '30'
  },
  {
    key: 'start', humanReadable: 'Start', visable: false, allowGrouping: true,  format: 'yMd',
    primaryKey: false, editable: true, type: 'date', dataType: 'datetime',
    isIdentity: false, width: '30'
  },
  {
    key: 'dueDate', humanReadable: 'End', allowGrouping: true, format: 'yMd',
    primaryKey: false, editable: true, type: 'date', dataType: 'datePickeredit',
    isIdentity: false, width: '30'
  },
  {
    key: 'orderedBy', humanReadable: 'Ordered By', type: 'string',
    primaryKey: false, allowGrouping: true, editable: true, dataType: 'TextBox',
    isIdentity: false, width: '25', visable: false
  },
  {
    key: 'status', humanReadable: 'Status', type: 'boolean', primaryKey: false, allowGrouping: true, editable: true, dataType: 'TextBox',
    isIdentity: false, width: '25'
  }
];
