/*
 * @CreateTime: Dec 12, 2018 2:26 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2018 2:28 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Workstations.Models;
using MediatR;

namespace BionicInventory.Application.Workstations.Queries.Collection {
    public class WorkStationGroupListQuery : IRequest<IEnumerable<WorkstationGroupView>> {

    }
}