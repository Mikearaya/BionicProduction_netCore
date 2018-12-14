/*
 * @CreateTime: Dec 12, 2018 2:00 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 14, 2018 9:47 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Workstations.Models;
using MediatR;

namespace BionicInventory.Application.Workstations.Queries.Single {
    public class SingleWorkstationGroupDetailQuery : IRequest<WorkstationGroupDetailView> {
        public uint Id { get; set; }
    }
}