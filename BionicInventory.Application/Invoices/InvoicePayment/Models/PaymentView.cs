/*
 * @CreateTime: Nov 6, 2018 8:34 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 6, 2018 8:37 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.Invoices.InvoicePayment.Models {
    public class PaymentView {

        public uint Id {get; set;}
        public uint InvoiceNo {get; set;}

        public float Amount {get; set;}

        public DateTime? DateAdded {get; set;}

        public DateTime? DateUpdated {get; set;}

        public string CasherName {get; set;}

        public string PreparedBy {get; set;}

    }
}