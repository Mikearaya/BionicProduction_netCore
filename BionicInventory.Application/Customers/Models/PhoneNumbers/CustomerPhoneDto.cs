/*
 * @CreateTime: Nov 27, 2018 3:17 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 27, 2018 3:17 PM
 * @Description: Modify Here, Please 
 */
/*
 * @CreateTime: Nov 27, 2018 3:16 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 27, 2018 3:17 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.Customers.Models.PhoneNumbers {
    public class CustomerPhoneDto {
        public uint? id { get; set; }

        [Required]
        public string type { get; set; }

        [Required]
        public string number { get; set; }

    }
}