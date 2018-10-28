/*
 * @CreateTime: Oct 28, 2018 8:03 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 28, 2018 8:03 PM
 * @Description: Modify Here, Please
 */



export const saleInvoiceColumnBluePrint = [
  {key: 'Id', humanReadable: 'Id', type: 'number', format: '', visable: true, width: 20 },
  {key: 'CustomerId', type: 'string', humanReadable: 'Customer Id', format: '',  visable: true, width: 25},
  {key: 'CustomerName', type: 'string', humanReadable: 'Customer Name', format: '', visable: true, width: 50},
  {key: 'TotalAmount', type: 'number', humanReadable: 'Before Tax', format: 'C2', visible: true, width: 25 },
  {key: 'TotalAfterTax', type: 'number', humanReadable: 'After Tax', format: 'C2', visible: true, width: 25 },
  {key: 'InvoiceType', type: 'string', humanReadable: 'Type', format: '', visable: true, width: 20},
  {key: 'Status', type: 'string', humanReadable: 'Status', format: '', visable: true, width: 20},
  {key: 'CreatedOn', type: 'date', humanReadable: 'Created', format: 'yMd', visable: true, width: 25},
  {key: 'DateAdded', type: 'date', humanReadable: 'Added On', format: 'yMd', visable: false, width: 30},
  {key: 'DueDate', type: 'date', humanReadable: 'Due Date', format: 'yMd', visable: false, width: 30}

];

