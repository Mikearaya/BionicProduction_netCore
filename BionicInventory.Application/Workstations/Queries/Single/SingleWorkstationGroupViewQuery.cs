/*
 * @CreateTime: Dec 14, 2018 9:51 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 14, 2018 9:51 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Workstations.Models;
using MediatR;

namespace BionicInventory.Application.Workstations.Queries.Single {
    public class SingleWorkstationGroupViewQuery : IRequest<WorkstationGroupView> {
        public uint Id { get; set; }
    }
}