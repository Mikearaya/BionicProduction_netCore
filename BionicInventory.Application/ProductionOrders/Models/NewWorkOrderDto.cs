/*
 * @CreateTime: Sep 10, 2018 8:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 9, 2018 11:20 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BionicInventory.Application.ProductionOrders.Models.WorkOrdersList;

namespace BionicInventory.Application.ProductionOrders.Models {
    public class NewWorkOrderDto : WorkOrderDto {

        [Required]
        public IEnumerable<NewWorkOrdersListDto> orderItems { get; set; }

    }
}