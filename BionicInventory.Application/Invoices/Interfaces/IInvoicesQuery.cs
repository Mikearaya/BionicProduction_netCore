using System.Collections.Generic;
using BionicInventory.Application.Interfaces;
using BionicInventory.Domain.Invoices;

namespace BionicInventory.Application.Invoices.Interfaces {
    public interface IInvoicesQuery {

        IEnumerable<Invoice> GetAllInvoices();
        Invoice GetInvoiceById(uint id);

        IEnumerable<Invoice> GetCustomerOrderInvoice(uint id);
        IEnumerable<Invoice> GetCustomerOrderQuoation(uint id);

    }
}