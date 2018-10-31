/*
 * @CreateTime: Sep 15, 2018 11:40 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 15, 2018 11:40 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.Customers.Models {
    public class UpdatedCustomerModel : CustomerDto {

        [Required]
        public uint id { set; get; }

    }
}