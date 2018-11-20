/*
 * @CreateTime: Nov 6, 2018 8:27 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 6, 2018 8:28 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Invoices.InvoicePayment.Models;
using BionicInventory.Domain.Invoices.InvoicePayment;

namespace BionicInventory.Application.Invoices.InvoicePayment.Interfaces {
    public interface IInvoicePaymentFactory {
        InvoicePayments CreateNewPayment(NewInvoicePaymentDto paymentDto);
    }
}