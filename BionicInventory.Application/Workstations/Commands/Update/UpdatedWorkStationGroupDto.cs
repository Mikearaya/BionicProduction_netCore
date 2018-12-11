/*
 * @CreateTime: Dec 12, 2018 1:32 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2018 1:32 AM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.Workstations.Commands.Update {
    public class UpdatedWorkStationGroupDto : IRequest {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public sbyte? Active { get; set; }

    }
}