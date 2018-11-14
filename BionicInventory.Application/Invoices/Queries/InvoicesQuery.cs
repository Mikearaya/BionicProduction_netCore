/*
 * @CreateTime: Nov 10, 2018 11:39 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 14, 2018 11:35 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Invoices.Interfaces;
using BionicInventory.Application.Invoices.Models.ViewModel;
using BionicInventory.Application.Invoices.Models.ViewModels;
using BionicInventory.Domain.Customers;
using BionicInventory.Domain.Invoices;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.Invoices.Queries {
    public class InvoicesQuery : IInvoicesQuery {
        private readonly IInventoryDatabaseService _database;
        private readonly ILogger<InvoicesQuery> _logger;

        public InvoicesQuery (IInventoryDatabaseService database,
            ILogger<InvoicesQuery> logger) {
            _database = database;
            _logger = logger;

        }
        public IEnumerable<Invoice> GetAllInvoices () {
            return QuariableInvoices ().ToList ();
        }
        private IQueryable<Invoice> QuariableInvoices () {
            return _database.Invoice
                .Select (i => new Invoice () {
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
        public IEnumerable<Invoice> GetCustomerOrderInvoice (uint id) {
            return QuariableInvoices ().Where (i => i.PurchaseOrderId == id).ToList ();

        }

        public IEnumerable<Invoice> GetCustomerOrderQuoation (uint id) {
            return QuariableInvoices ().Where (i => i.PurchaseOrderId == id &&
                    i.InvoiceType.ToUpper () == "QUOTATION")
                .ToList ();
        }

        public Invoice GetInvoiceById (uint id) {
            return QuariableInvoices ()
                .FirstOrDefault (i => i.Id == id);
        }

        public IEnumerable<InvoiceStatusView> GetCustomerOrderInvoiceStatus (uint customerOrderId = 0) {
            var customerInvoice = _database.Invoice
                .GroupBy (dd => dd.PurchaseOrderId).Select (sd => new {
                    id = sd.Key,
                        Detail = sd.Select (detail => new {
                            Id = detail.Id,
                                customerOrderId = detail.PurchaseOrderId,
                                DateAdded = detail.DateAdded,
                                DueDate = detail.DueDate,
                                PaymentMethod = detail.PaymentMethod,
                                customer = detail.PurchaseOrder.Client.FullName (),
                                customerId = detail.PurchaseOrder.ClientId,
                                InvoiceType = detail.InvoiceType,
                                Tax = detail.Tax,
                                PaidAmount = detail.InvoicePayments.Sum (totalPayment => totalPayment.Amount),
                                TotalAmount = detail.InvoiceDetail.Sum (paidAmount => (double) (paidAmount.Quantity * paidAmount.UnitPrice))
                        }),
                });

            if (customerOrderId != 0) {
                customerInvoice = customerInvoice.Where (i => i.id == customerOrderId);
            }

            List<InvoiceStatusView> invoiceSummary = new List<InvoiceStatusView> ();
            foreach (var item in customerInvoice) {

                foreach (var detail in item.Detail) {
                    InvoiceStatusView invoiceStatus = new InvoiceStatusView () {
                        Id = detail.Id,
                        DateAdded = detail.DateAdded,
                        DueDate = detail.DueDate,
                        TotalAmount = detail.TotalAmount,
                        PaymentMethod = detail.PaymentMethod,
                        PaidAmount = detail.PaidAmount,
                        InvoiceType = detail.InvoiceType,
                        CustomerId = detail.customerId,
                        CustomerName = detail.customer,
                        CustomerOrderId = detail.customerOrderId,
                        CreatedOn = detail.DateAdded,
                        TotalAfterTax = (detail.Tax != 0 ? detail.TotalAmount + (detail.TotalAmount * detail.Tax / 100) : detail.TotalAmount)
                    };

                    if (detail.TotalAmount - detail.PaidAmount == 0) {
                        invoiceStatus.Status = "Paid";
                    } else if (detail.TotalAmount - detail.PaidAmount > 0 && detail.PaidAmount > 0) {
                        var paidPercent = (detail.PaidAmount / detail.TotalAmount) * 100;
                        invoiceStatus.Status = $"Partialy Paid\n {paidPercent}%";
                    } else if (detail.TotalAmount - detail.PaidAmount > 0) {
                        invoiceStatus.Status = "UnPaid";
                    }
                    invoiceSummary.Add (invoiceStatus);
                }

            }

            return invoiceSummary;
        }

        public InvoiceDetailView GetInvoiceDetailView (uint id) {
            return _database.Invoice
                .Where (i => i.Id == id).Select (i => new InvoiceDetailView () {
                    Id = i.Id,
                        invoiceType = i.InvoiceType,
                        CreatedOn = i.DateAdded,
                        DeliveryDate = i.DueDate,
                        preparedBy = i.PreparedByNavigation.FullName (),
                        preparedById = i.PreparedBy,
                        tax = i.Tax,
                        note = i.Note,
                        discount = i.Discount,
                        customer = i.InvoiceDetail.Select (d => new { info = d.SalesOrder.PurchaseOrder.Client }),
                        invoiceItems = i.InvoiceDetail.Select (d => new InvoiceItems () {
                            ItemName = d.SalesOrder.Item.Name,
                                itemId = d.SalesOrder.ItemId,
                                unitPrice = d.UnitPrice,
                                quantity = d.Quantity,
                                discount = d.Discount,
                                customerOrderItemId = d.SalesOrderId,
                                id = d.Id

                        })

                }).FirstOrDefault ();

        }

    }
}