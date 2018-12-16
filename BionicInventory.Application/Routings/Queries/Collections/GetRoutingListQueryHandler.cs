/*
 * @CreateTime: Dec 17, 2018 12:46 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 17, 2018 12:46 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Threading;
using MediatR;

namespace BionicInventory.Application.Routings.Queries.Collections {
    public class GetRoutingListQueryHandler : IRequestHandler<GetRoutingListQuery, IEnumerable<RoutingListView>> {
        public System.Threading.Tasks.Task<IEnumerable<RoutingListView>> Handle (GetRoutingListQuery request, CancellationToken cancellationToken) {
            throw new System.NotImplementedException ();
        }
    }
}