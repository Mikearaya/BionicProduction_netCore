/*
 * @CreateTime: Dec 17, 2018 9:49 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 17, 2018 9:56 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Routings.Models;
using MediatR;

namespace BionicInventory.Application.Routings.Queries.Single {
    public class GetProductRoutingListQuery : IRequest<IEnumerable<RoutingView>> {
        public uint ItemId { get; set; }
    }
}