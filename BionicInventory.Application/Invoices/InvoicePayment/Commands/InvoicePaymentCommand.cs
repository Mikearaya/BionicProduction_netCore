/*
 * @CreateTime: Nov 6, 2018 8:56 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 12, 2018 1:27 AM
 * @Description: Modify Here, Please 
 * 
 */

using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Invoices.InvoicePayment.Interfaces;
using BionicInventory.Domain.Invoices.InvoicePayment;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.Invoices.InvoicePayment.Commands {
    public class InvoicePaymentCommand : IInvoicePaymentCommand {
        private readonly ILogger<InvoicePaymentCommand> _logger;
        private readonly IInventoryDatabaseService _database;

        public InvoicePaymentCommand (IInventoryDatabaseService database,
            ILogger<InvoicePaymentCommand> logger) {
            _logger = logger;
            _database = database;
        }

        public InvoicePayments AddPayment (InvoicePayments payment) {
            _database.InvoicePayments.Add (payment);
            _database.Save();
            return payment;
        }

        public bool DeletePayment (InvoicePayments deletedPayment) {
            var result = _database.InvoicePayments.Remove (deletedPayment);
            _database.Save();
            return (result != null) ? true : false;
        }

        public bool UpdatePayment (InvoicePayments payment) {
            var result = _database.InvoicePayments.Update (payment);
            return (result != null) ? true : false;
        }
    }
}