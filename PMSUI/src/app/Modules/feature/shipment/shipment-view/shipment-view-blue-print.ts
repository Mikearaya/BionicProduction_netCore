
export const shipmentBluePrint = [
  {
    key: 'id', humanReadable: 'ID', primaryKey: true, type: 'number', dataType: 'numericedit',
    width: '15', visable: true,
  },
  {
    key: 'CustomerOrderId', humanReadable: 'Customer Order', type: 'number', allowGrouping: true,
    dataType: 'numericedit', width: '28', visable: true,
  },
  {
    key: 'bookingUser', humanReadable: 'Sales Person', type: 'string', allowGrouping: true, dataType: 'textboxedit',
    width: '28', visable: true,
  },
  {
    key: 'deliveryDate', humanReadable: 'Delivery Date', type: 'date', allowGrouping: true,
    dataType: 'datePickeredit', width: '28', format: 'yMd', visable: true,
  },
  {
    key: 'status', humanReadable: 'Status', type: 'string', allowGrouping: true,
    dataType: 'textboxedit', width: '28', format: '', visable: true,
  },
  {
    key: 'dateAdded', humanReadable: 'Date Added', type: 'date', allowGrouping: true, visable: true,
    dataType: 'datePickeredit', width: '28', format: 'yMd'
  },
  {
    key: 'dateUpdated', humanReadable: 'Updated', type: 'date', allowGrouping: true, dataType: 'datePickeredit', width: '28', format: 'yMd'
    , visable : false
  }
];

// used for detail view component grid column mapping
export const shipmentDetailBluePrint = [
  {
    key: 'customerOrderItemId', humanReadable: 'Order Item',  type: 'number', dataType: 'numericedit',
    width: '15', visable: false,
  },
  {
    key: 'itemName', humanReadable: 'Item Name', type: 'string',
    dataType: 'textboxedit', width: '28', visable: true,
  },
  {
    key: 'bookedQuantity', humanReadable: 'Booked Quantity', type: 'number',  dataType: 'numericedit',
    width: '28', visable: true,
  },
  {
    key: 'pickedQuantity', humanReadable: 'Picked Quantity', type: 'number',
    dataType: 'numericedit', width: '28', visable: true,
  },
  {
    key: 'remainingShipments', humanReadable: 'Remaining', type: 'number',
    dataType: 'numericedit', width: '28', visable: true,
  },
  {
    key: 'status', humanReadable: 'Status', type: 'string',
    dataType: 'textboxedit', width: '28', visable: true,
  }
];
