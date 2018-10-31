using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Invoices.Interfaces;
using BionicInventory.Domain.Invoices;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.Invoices.Commands {
    public class InvoicesCommand : IInvoicesCommand {
        private readonly IInventoryDatabaseService _database;
        private readonly ILogger<IInvoicesCommand> _logger;

        public InvoicesCommand(IInventoryDatabaseService database,
                            ILogger<IInvoicesCommand> logger) {
                                _database = database;
                                _logger = logger;
                            }
        public Invoice CreateInvoice (Invoice newInvoice) {
            _database.Invoice.Add(newInvoice);
            _database.Save();

            return newInvoice;
        }

        public bool DeleteInvoice(Invoice deletedInvoice)
        {
            _database.Invoice.Remove(deletedInvoice);
            _database.Save();
            return true;
        }

        public bool UpdateInvoice(Invoice updatedInvoice)
        {
            _database.Invoice.Update(updatedInvoice);
            _database.Save();
            return true;
        }
    }
}