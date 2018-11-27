/*
 * @CreateTime: Nov 27, 2018 3:00 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 27, 2018 4:11 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.Customers.Models {
    public class CustomerDto {
        [Required]
        public string FullName { set; get; }

        [MaxLength (10)]
        [MinLength (10)]
        public string tin { set; get; }
        public string email { set; get; }

        public int? paymentPeriod {get; set;}
        public double? creditLimit {get; set;}
        public string poBox {get; set;}
        public double? taxAmount {get; set;}
        [Required]
        public string type { set; get; }
    }

}