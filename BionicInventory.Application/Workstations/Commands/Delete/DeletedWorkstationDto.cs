/*
 * @CreateTime: Dec 12, 2018 1:49 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2018 1:49 AM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.Workstations.Commands.Delete {
    public class DeletedWorkstationDto : IRequest {
        public uint Id { get; set; }

    }
}