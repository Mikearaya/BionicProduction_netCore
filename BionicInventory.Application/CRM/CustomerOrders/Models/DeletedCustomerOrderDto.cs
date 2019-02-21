/*
 * @CreateTime: Feb 21, 2019 8:48 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 21, 2019 8:49 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.CRM.CustomerOrders.Models {
    public class DeletedCustomerOrderDto : IRequest {
        public uint Id { get; set; }
    }
}