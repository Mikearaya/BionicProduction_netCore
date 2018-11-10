/*
 * @CreateTime: Oct 26, 2018 9:21 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 10, 2018 11:40 PM
 * @Description: Modify Here, Please 
 */

using BionicInventory.Application.Invoices.Models;
using BionicInventory.Domain.Invoices;

namespace BionicInventory.Application.Invoices.Interfaces {

    public interface IInvoiceFactory {
        Invoice NewInvoice (NewInvoiceDto newInvoice);
    }
}