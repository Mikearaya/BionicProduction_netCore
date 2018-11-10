/*
 * @CreateTime: Nov 10, 2018 11:40 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 10, 2018 11:40 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Interfaces;
using BionicInventory.Domain.Invoices;

namespace BionicInventory.Application.Invoices.Interfaces {
    public interface IInvoicesCommand {
        Invoice CreateInvoice (Invoice newInvoice);

        bool UpdateInvoice (Invoice updateInvoice);
        bool DeleteInvoice (Invoice DeletedInvoice);

    }
}