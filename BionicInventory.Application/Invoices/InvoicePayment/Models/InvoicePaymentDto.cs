/*
 * @CreateTime: Nov 6, 2018 8:29 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 6, 2018 11:36 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.Invoices.InvoicePayment.Models {
    public abstract class InvoicePaymentDto {
        [Required]
        public uint InvoiceNo { get; set; }

        [Required]
        public float Amount { get; set; }

        [Required]
        public uint CashierId { get; set; }

    }
}