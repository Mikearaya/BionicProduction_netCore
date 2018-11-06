/*
 * @CreateTime: Nov 6, 2018 8:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 6, 2018 8:34 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.Invoices.InvoicePayment.Models {
    public class UpdatedPaymentDto : InvoicePaymentDto {

        [Required]
        public uint Id { get; set; }

    }
}