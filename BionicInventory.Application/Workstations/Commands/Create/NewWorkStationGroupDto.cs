/*
 * @CreateTime: Dec 12, 2018 1:25 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2018 1:26 AM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.Workstations.Commands.Create {
    public class NewWorkStationGroupDto : IRequest {
        public string Name { get; set; }
        public string Description { get; set; }
        public sbyte? Active { get; set; }

    }
}