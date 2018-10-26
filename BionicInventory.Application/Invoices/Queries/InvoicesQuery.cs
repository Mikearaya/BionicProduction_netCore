using System.Collections.Generic;
using System.Linq;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Invoices.Interfaces;
using BionicInventory.Domain.Invoices;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.Invoices.Queries {
    public class InvoicesQuery : IInvoicesQuery
    {
        private readonly IInventoryDatabaseService _database;
        private readonly ILogger<InvoicesQuery> _logger;

        public InvoicesQuery(IInventoryDatabaseService database,
        ILogger<InvoicesQuery> logger) {
            _database = database;
            _logger = logger;

        }
        public IEnumerable<Invoice> GetAllInvoices()
        {
            return _database.Invoice.ToList(); 
        }

        public IEnumerable<Invoice> GetCustomerOrderInvoice(uint id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Invoice> GetCustomerOrderQuoation(uint id)
        {
            throw new System.NotImplementedException();
        }

        public Invoice GetInvoiceById(uint id)
        {
            return _database.Invoice.FirstOrDefault(i => i.Id == id);
        }
    }
}