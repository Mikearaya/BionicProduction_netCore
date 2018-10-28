using System.Collections.Generic;
using BionicInventory.Application.Interfaces;
using BionicInventory.Application.Invoices.Models.ViewModel;
using BionicInventory.Domain.Invoices;

namespace BionicInventory.Application.Invoices.Interfaces {
    public interface IInvoicesQuery {

        IEnumerable<Invoice> GetAllInvoices();
        Invoice GetInvoiceById(uint id);
        IEnumerable<InvoiceStatusView> GetCustomerOrderInvoiceStatus(uint customerOrderId = 0);
        IEnumerable<Invoice> GetCustomerOrderInvoice(uint id);
        IEnumerable<Invoice> GetCustomerOrderQuoation(uint id);

    }
}