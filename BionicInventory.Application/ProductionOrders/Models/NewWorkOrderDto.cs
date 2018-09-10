/*
 * @CreateTime: Sep 10, 2018 8:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2018 8:33 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;

namespace BionicInventory.Application.ProductionOrders.Models
{
    public class NewWorkOrderDto
    {
        public string description;
        public uint orderedBy;

        public IList<NewWorkOrderDto> produtionOrdersList;
        
    }
}