using System.Collections.Generic;
using BionicInventory.Application.Invoices.Interfaces;
using BionicInventory.Domain.Invoices.InvoicePayment;

namespace BionicInventory.Application.Invoices.Queries {
    public class InvoicePaymentsQuery : IInvoicePaymentsQuery {
        public IEnumerable<InvoicePayments> GetAll () {
            throw new System.NotImplementedException ();
        }

        public InvoicePayments GetById (uint id) {
            throw new System.NotImplementedException ();
        }
    }
}