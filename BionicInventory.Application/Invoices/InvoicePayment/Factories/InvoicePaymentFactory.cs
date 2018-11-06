/*
 * @CreateTime: Nov 6, 2018 11:35 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 6, 2018 11:36 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Invoices.InvoicePayment.Interfaces;
using BionicInventory.Application.Invoices.InvoicePayment.Models;
using BionicInventory.Domain.Invoices.InvoicePayment;

namespace BionicInventory.Application.Invoices.InvoicePayment.Factories {
    public class InvoicePaymentFactory : IInvoicePaymentFactory {
        public InvoicePayments CreateNewPayment (NewInvoicePaymentDto paymentDto) {

            return new InvoicePayments () {
                InvoiceNo = paymentDto.InvoiceNo,
                    Amount = paymentDto.Amount,
                    CashierId = paymentDto.CashierId,

            };
        }
    }
}