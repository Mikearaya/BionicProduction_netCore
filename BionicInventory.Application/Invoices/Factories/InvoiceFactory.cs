/*
 * @CreateTime: Oct 26, 2018 10:13 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 4, 2018 9:08 PM
 * @Description: Modify Here, Please 
 */



using BionicInventory.Application.Invoices.Interfaces;
using BionicInventory.Application.Invoices.Models;
using BionicInventory.Domain.Invoices;
using BionicInventory.Domain.Invoices.InvoiceDetails;

namespace BionicInventory.Application.Invoices.Factories {

    public class InvoiceFactory : IInvoiceFactory
    {
        public Invoice NewInvoice(NewInvoiceDto newInvoice)
        {
            Invoice invoice =  new Invoice() {
                    PurchaseOrderId = newInvoice.CustomerOrderId,
                    InvoiceType = newInvoice.InvoiceType,
                    PaymentMethod = newInvoice.PaymentMethod,
                    CreatedBy = newInvoice.CreatedBy,
                    DueDate = newInvoice.DueDate,
                    Discount = newInvoice.Discount,
                    Tax = newInvoice.Tax
            };

            if(newInvoice.Note != null && newInvoice.Note.Trim() != "") {
                invoice.Note = newInvoice.Note;
            }

            foreach (var item in newInvoice.InvoiceItems)
            {
                    invoice.InvoiceDetail.Add(new InvoiceDetail() {
                            Quantity = (int) item.Quantity,
                            Discount = item.Discount,
                            Note = item.Note,
                            SalesOrderId = item.CustomerOrderItemId,
                            UnitPrice = item.UnitPrice

                    });               
            }

            return invoice;
        }
    }
}