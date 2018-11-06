/*
 * @CreateTime: Nov 6, 2018 8:28 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 6, 2018 8:28 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Domain.Invoices.InvoicePayment;

namespace BionicInventory.Application.Invoices.InvoicePayment.Interfaces {
    public interface IInvoicePaymentCommand {

        InvoicePayments AddPayment(InvoicePayments payment);

        bool UpdatePayment(InvoicePayments payment);

        bool DeletePayment(InvoicePayments deletedPayment);



    }
}