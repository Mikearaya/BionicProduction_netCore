/*
 * @CreateTime: Oct 26, 2018 9:09 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 26, 2018 10:12 PM
 * @Description: Modify Here, Please 
 */



using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.Invoices.Models {

    public abstract class InvoiceDto {
        [Required]
        public uint CustomerOrderId {get; set;}
        public uint CreatedBy {get; set;}
        public string Status {get; set;}
        
        [Required]
        public  string InvoiceType {get; set;}
        [Required]
        public string PaymentMethod {get; set;}
        public DateTime? DueDate {get; set;}
        public DateTime? CreatedOn {get; set;}
        public string Note {get; set;}

        public float Discount {get; set;} = 0;
        public float Tax {get; set;} = 0;
    }

}