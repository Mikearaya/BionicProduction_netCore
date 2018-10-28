/*
 * @CreateTime: Oct 28, 2018 8:01 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 28, 2018 8:01 PM
 * @Description: Modify Here, Please 
 */

using System;

namespace BionicInventory.Application.Invoices.Models.ViewModel {

    public class InvoiceStatusView {

        private string _invoiceType =  "";

        public uint Id {get; set;}
        public uint CustomerId {get; set;}
        public string InvoiceType {get {
            return _invoiceType;
        } set {
            _invoiceType = value.ToLower();
        }}

        public DateTime? CreatedOn {get; set;}
        public DateTime? DateAdded {get; set;}
        public string CustomerName {get; set;}

        public string Status {get; set;}
        public double? TotalAfterTax {get; set;}
        public double? TotalAmount {get; set;}
        public double? PaidAmount {get; set;}
        public DateTime? DueDate {get; set;}
    }

}