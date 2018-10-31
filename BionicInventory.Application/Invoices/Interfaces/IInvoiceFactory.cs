/*
 * @CreateTime: Oct 26, 2018 9:21 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 26, 2018 9:25 PM
 * @Description: Modify Here, Please 
 */


using BionicInventory.Application.Invoices.Models;
using BionicInventory.Domain.Invoices;

namespace BionicInventory.Application.Invoices.Interfaces {

    public interface IInvoiceFactory {
        Invoice NewInvoice (NewInvoiceDto newInvoice);
    }
}