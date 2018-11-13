/*
 * @CreateTime: Nov 10, 2018 11:40 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 10, 2018 11:40 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Interfaces;
using BionicInventory.Application.Invoices.Models.ViewModel;
using BionicInventory.Application.Invoices.Models.ViewModels;
using BionicInventory.Domain.Invoices;

namespace BionicInventory.Application.Invoices.Interfaces {
    public interface IInvoicesQuery {

        IEnumerable<Invoice> GetAllInvoices ();
        Invoice GetInvoiceById (uint id);
        IEnumerable<InvoiceStatusView> GetCustomerOrderInvoiceStatus (uint customerOrderId = 0);
        IEnumerable<Invoice> GetCustomerOrderInvoice (uint id);
        IEnumerable<Invoice> GetCustomerOrderQuoation (uint id);

        InvoiceDetailView GetInvoiceDetailView (uint id);

    }
}