/*
 * @CreateTime: Jan 19, 2019 3:43 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 25, 2019 8:38 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.Models {
    public class AuthenticationModel {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        public bool RemindeMe { get; set; }
    }
}