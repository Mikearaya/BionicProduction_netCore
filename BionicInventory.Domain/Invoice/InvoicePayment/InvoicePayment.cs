/*
 * @CreateTime: Nov 6, 2018 8:46 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 12, 2018 12:57 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.Employees;

namespace BionicInventory.Domain.Invoices.InvoicePayment {
    public class InvoicePayments {
        public uint Id { get; set; }
        public uint InvoiceNo { get; set; }
        public double Amount { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public uint CashierId { get; set; }
        public int? PrintCount { get; set; }

        public Employee Cashier { get; set; }
        public Invoice InvoiceNoNavigation { get; set; }
    }
}