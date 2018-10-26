/*
 * @CreateTime: Oct 26, 2018 9:23 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 26, 2018 9:25 PM
 * @Description: Modify Here, Please 
 */


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.Invoices.Models {

    public class NewInvoiceDto: InvoiceDto {

     
        [Required]
        public List<NewInvoiceItemDto> InvoiceItems  = new List<NewInvoiceItemDto>();   
    }

}