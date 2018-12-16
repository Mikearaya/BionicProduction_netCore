/*
 * @CreateTime: Dec 17, 2018 12:45 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 17, 2018 12:45 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Routings.Models;
using MediatR;

namespace BionicInventory.Application.Routings.Queries.Collections {
    public class GetRoutingListQuery : IRequest<IEnumerable<RoutingListView>> {

    }
}