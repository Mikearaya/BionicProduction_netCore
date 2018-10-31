/*
 * @CreateTime: Oct 2, 2018 8:32 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 2, 2018 9:14 PM
 * @Description: Modify Here, Please 
 */
using System;
using BionicInventory.Domain.Employees;
using BionicInventory.Domain.FinishedProducts;
using BionicInventory.Domain.Invoices.InvoiceDetails;

namespace BionicInventory.Domain.Sale {
    public class Sales {

        public uint Id { get; set; }
        public uint InvoiceId { get; set; }
        public uint StockId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public uint StoreKeeper { get; set; }

        public InvoiceDetail Invoice { get; set; }
        public FinishedProduct Stock { get; set; }
        public Employee StoreKeeperNavigation { get; set; }
    }
}