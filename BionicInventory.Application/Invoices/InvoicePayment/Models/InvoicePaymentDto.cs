/*
 * @CreateTime: Nov 6, 2018 8:29 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 12, 2018 1:25 AM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.Invoices.InvoicePayment.Models {
    public abstract class InvoicePaymentDto {
        [Required]
        public uint Id { get; set; }

        [Required]
        public float Amount { get; set; }

        [Required]
        public uint CashierId { get; set; } = 11;

    }
}