/*
 * @CreateTime: Nov 6, 2018 8:55 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 12, 2018 1:11 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Invoices.InvoicePayment.Interfaces;
using BionicInventory.Application.Invoices.InvoicePayment.Models;
using BionicInventory.Domain.Invoices.InvoicePayment;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.Invoices.InvoicePayment.Queries {
    public class InvoicePaymentQuery : IInvoicePaymentQuery {
        private readonly IInventoryDatabaseService _database;
        private readonly ILogger<IInvoicePaymentQuery> _logger;

        public InvoicePaymentQuery (IInventoryDatabaseService database,
            ILogger<IInvoicePaymentQuery> logger) {
            _database = database;
            _logger = logger;
        }
        public IEnumerable<InvoicePayments> GetAllInvoicePayments (uint invoiceId) {
            try {
                return _database.InvoicePayments.Where (p => p.InvoiceNo == invoiceId).ToList ();
            } catch (Exception e) {
                _logger.LogError (500, e, e.Message, e);
                return null;
            }

        }

        public IEnumerable<InvoicePaymentSummaryView> GetCustomerOrderIvoiceSummary (uint customerOrderId) {
            var x = _database.Invoice
                .Where (p => p.PurchaseOrderId == customerOrderId)
                .GroupBy (p => p.PurchaseOrderId)
                .Select (payment => new {
                    id = payment.Key,
                        summary = payment.Select (sum => new InvoicePaymentSummaryView () {
                            InvoiceNo = sum.Id,
                                TotalAmount = (float) sum.InvoiceDetail.Sum (i => (float) i.Quantity * (float) i.UnitPrice),
                                PaidAmount = (float) sum.InvoicePayments.Sum (p => p.Amount),
                                PreparedBy = sum.PreparedByNavigation.FullName ()
                        })
                });
            List<InvoicePaymentSummaryView> summaryView = new List<InvoicePaymentSummaryView> ();
            foreach (var item in x) {
                foreach (var summary in item.summary) {
                    summary.InvoiceNo = item.id;
                    summary.RemainingAmount = summary.TotalAmount - summary.PaidAmount;

                    if (summary.TotalAmount == summary.PaidAmount) {
                        summary.Status = "Paid";
                    } else if (summary.TotalAmount > summary.PaidAmount && summary.PaidAmount == 0) {
                        summary.Status = "Partially Paid";
                    } else {
                        summary.Status = "UnPaid";
                    }
                }

            }
            return summaryView;
        }

        public InvoicePayments GetInvoicePaymentById (uint paymentId) {
            try {
                return _database.InvoicePayments.Where (p => p.Id == paymentId).FirstOrDefault ();
            } catch (Exception e) {
                _logger.LogError (500, e, e.Message, e);
                return null;
            }
        }

        public InvoicePaymentSummaryView GetInvoicePaymentSummary (uint invoiceId) {
            return _database.Invoice
                .Where (p => p.Id == invoiceId)
                .Select (payment => new InvoicePaymentSummaryView {
                    InvoiceNo = payment.Id,
                        TotalAmount = payment.InvoiceDetail.Sum (i => ((double) i.Quantity) * i.UnitPrice),
                        PaidAmount = payment.InvoicePayments.Sum (p => (double) p.Amount),
                        PreparedBy = payment.PreparedByNavigation.FullName ()

                }).FirstOrDefault ();
        }

        public IEnumerable<PaymentView> GetInvoicePaymentsView (uint invoiceId) {
            return _database.InvoicePayments
                .Where (i => i.InvoiceNo == invoiceId)
                .Select (p => new PaymentView () {
                    Id = p.Id,
                        InvoiceNo = p.InvoiceNo,
                        Amount = (float) p.Amount,
                        DateAdded = p.DateAdded,
                        DateUpdated = p.DateUpdated,
                        CasherName = p.Cashier.FullName (),
                        PreparedBy = p.InvoiceNoNavigation.PreparedByNavigation.FullName ()
                })
                .OrderByDescending (o => o.DateAdded)
                .ToList ();
        }
    }
}