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

        [Required]
        public string type { set; get; }
    }

}