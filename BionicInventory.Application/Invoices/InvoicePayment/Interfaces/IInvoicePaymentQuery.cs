/*
 * @CreateTime: Nov 6, 2018 8:27 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 12, 2018 1:12 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Invoices.InvoicePayment.Models;
using BionicInventory.Domain.Invoices.InvoicePayment;

namespace BionicInventory.Application.Invoices.InvoicePayment.Interfaces {
    public interface IInvoicePaymentQuery {

        IEnumerable<InvoicePayments> GetAllInvoicePayments(uint invoiceId);
        InvoicePayments GetInvoicePaymentById(uint paymentId);
        IEnumerable<PaymentView> GetInvoicePaymentsView (uint invoiceId);

        IEnumerable<InvoicePaymentSummaryView> GetCustomerOrderIvoiceSummary(uint customerOrderId);

        InvoicePaymentSummaryView GetInvoicePaymentSummary (uint invoiceId);

    }
}