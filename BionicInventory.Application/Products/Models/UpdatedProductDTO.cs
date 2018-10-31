/*
 * @CreateTime: Sep 9, 2018 8:25 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 9, 2018 8:25 PM
 * @Description: Modify Here, Please 
 */
/*
 * @CreateTime: Sep 9, 2018 6:14 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 2, 2018 10:49 PM
 * @Description: Modify Here, Please 
 */

using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.Products.Models {
    public class UpdatedProductDto: ProductDto {

        [Key]
        [Required]
        public uint id {get; set;}


    }
}