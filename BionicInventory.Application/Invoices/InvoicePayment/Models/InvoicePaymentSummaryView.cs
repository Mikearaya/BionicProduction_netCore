/*
 * @CreateTime: Nov 6, 2018 8:37 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 6, 2018 8:40 PM
 * @Description: Modify Here, Please 
 */
namespace BionicInventory.Application.Invoices.InvoicePayment.Models {
    public class InvoicePaymentSummaryView {
        public uint InvoiceNo { get; set; }
        public double TotalAmount { get; set; }

        public double PaidAmount { get; set; }
        public double RemainingAmount { get; set; }
        public string Status { get; set; }

        public string PreparedBy {get; set;}

    }
}