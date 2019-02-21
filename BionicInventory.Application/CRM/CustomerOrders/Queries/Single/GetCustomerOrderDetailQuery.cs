/*
 * @CreateTime: Feb 21, 2019 10:14 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 21, 2019 10:15 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.CRM.CustomerOrders.Models;
using MediatR;

namespace BionicInventory.Application.CRM.CustomerOrders.Queries.Single {
    public class GetCustomerOrderDetailQuery : IRequest<CustomerOrderDetailView> {
        public uint Id { get; set; }
    }
}