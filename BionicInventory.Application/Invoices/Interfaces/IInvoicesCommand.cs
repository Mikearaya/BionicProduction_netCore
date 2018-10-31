using BionicInventory.Application.Interfaces;
using BionicInventory.Domain.Invoices;

namespace BionicInventory.Application.Invoices.Interfaces {
    public interface IInvoicesCommand  {
        Invoice CreateInvoice (Invoice newInvoice);

        bool UpdateInvoice (Invoice updateInvoice);
        bool DeleteInvoice (Invoice DeletedInvoice);

    }
}