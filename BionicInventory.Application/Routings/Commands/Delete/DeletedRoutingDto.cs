/*
 * @CreateTime: Dec 17, 2018 12:10 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 17, 2018 12:10 AM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.Routings.Commands.Delete {
    public class DeletedRoutingDto : IRequest {
        public uint Id { get; set; }
    }
}