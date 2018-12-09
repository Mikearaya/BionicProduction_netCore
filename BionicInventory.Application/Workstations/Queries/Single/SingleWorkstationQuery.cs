/*
 * @CreateTime: Dec 9, 2018 11:35 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 9, 2018 11:35 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Workstations.Models;
using MediatR;

namespace BionicInventory.Application.Workstations.Queries.Single {
    public class SingleWorkstationQuery : IRequest<WorkstationView> {
        public uint Id { get; set; }
    }
}