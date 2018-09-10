/*
 * @CreateTime: Sep 10, 2018 8:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2018 10:21 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.ProductionOrders.Models
{
    public class NewWorkOrderDto
    {
       
        [Required]
        public string Description;
        [Required]
        public uint OrderedBy;

        public IList<NewWorkOrderDto> ProdutionOrdersList;
        
    }
}