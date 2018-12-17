/*
 * @CreateTime: Dec 17, 2018 8:55 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 17, 2018 8:57 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Routings.Models;
using MediatR;

namespace BionicInventory.Application.Routings.Queries.Single {
    public class GetRoutingDetailQuery : IRequest<RoutingDetailView> {
        public uint Id { get; set; }
    }
}