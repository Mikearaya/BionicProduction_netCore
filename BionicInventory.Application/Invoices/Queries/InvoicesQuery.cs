using System.Collections.Generic;
using BionicInventory.Application.Invoices.Interfaces;
using BionicInventory.Domain.Invoices;

namespace BionicInventory.Application.Invoices.Queries {
    public class InvoicesQuery : IInvoicesQuery {
        public IEnumerable<Invoice> GetAll () {
            throw new System.NotImplementedException ();
        }

        public Invoice GetById (uint id) {
            throw new System.NotImplementedException ();
        }
    }
}