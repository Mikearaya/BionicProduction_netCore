using System;
using System.Collections.Generic;
using System.Linq;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Invoices.Interfaces;
using BionicInventory.Application.Invoices.Models.ViewModel;
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
            return QuariableInvoices().ToList();
        }
        private IQueryable<Invoice> QuariableInvoices() {
            return _database.Invoice
                                    .Select(i => new Invoice(){
                                                Id = i.Id,
                                                InvoiceType = i.InvoiceType,
                                                PurchaseOrderId = i.PurchaseOrderId,
                                                DateAdded = i.DateAdded,
                                                DateUpdated = i.DateUpdated,
                                                Discount = i.Discount,
                                                DueDate = i.DueDate,
                                                Note = i.Note,
                                                PrintCount = i.PrintCount,
                                                InvoiceDetail = i.InvoiceDetail,
                                                InvoicePayments = i.InvoicePayments
                                    });
        }
        public IEnumerable<Invoice> GetCustomerOrderInvoice(uint id)
        {
            return  QuariableInvoices().Where(i => i.PurchaseOrderId == id).ToList();

        }

        public IEnumerable<Invoice> GetCustomerOrderQuoation(uint id)
        {
            return QuariableInvoices().Where(i => i.PurchaseOrderId == id &&
                                                i.InvoiceType.ToUpper() == "QUOTATION"  )
                                                .ToList();
        }

        public Invoice GetInvoiceById(uint id)
        {
            return QuariableInvoices()
                            .FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<InvoiceStatusView> GetCustomerOrderInvoiceStatus(uint customerOrderId = 0) {
                var customerInvoice = _database.Invoice
                                    .GroupBy(dd => dd.PurchaseOrderId).Select(sd => new {
                    id = sd.Key,
                    TotalAmount = sd.Sum(s => s.InvoiceDetail.Sum(paidAmount => (double)  (paidAmount.Quantity *  paidAmount.UnitPrice))),
                    PaidAmount = sd.Sum(s => s.InvoicePayments.Sum(totalPayment => totalPayment.Amount)),
                    Invoice = sd,
                    Customer = sd.Select(p => p.PurchaseOrder.Client).FirstOrDefault()
                });

                if(customerOrderId != 0) {
                customerInvoice =    customerInvoice.Where(i => i.id == customerOrderId);
                }

                    List<InvoiceStatusView> invoiceSummary = new List<InvoiceStatusView>();
                        foreach (var item in customerInvoice)
                        {

                            foreach (var detail in item.Invoice)
                            {
                                InvoiceStatusView invoiceStatus = new InvoiceStatusView() {
                                    Id = detail.Id,
                                    CreatedOn = detail.CreatedOn,
                                    DateAdded = detail.DateAdded,
                                    DueDate = detail.DueDate,
                                    TotalAmount = item.TotalAmount,
                                    PaidAmount = item.PaidAmount,
                                    InvoiceType = detail.InvoiceType,
                                    CustomerId = item.Customer.Id,
                                    CustomerName = item.Customer.FullName(),

                                    TotalAfterTax = (detail.Tax != 0 ? item.TotalAmount + (item.TotalAmount * detail.Tax/100): item.TotalAmount)
                                };
                
                                if(item.TotalAmount - item.PaidAmount == 0) {
                                    invoiceStatus.Status = "Paid";
                                } else if(item.TotalAmount - item.PaidAmount > 0 && item.PaidAmount > 0 ) {
                                    invoiceStatus.Status = "Partialy Paid";
                                } else if(item.TotalAmount - item.PaidAmount > 0) {
                                        invoiceStatus.Status = "UnPaid";
                                }
                                invoiceSummary.Add(invoiceStatus);
                            }

                        }

                return invoiceSummary;
        }
    }
}