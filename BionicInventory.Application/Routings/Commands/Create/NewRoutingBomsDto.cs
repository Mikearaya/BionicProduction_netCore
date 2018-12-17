/*
 * @CreateTime: Dec 16, 2018 11:18 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 17, 2018 1:00 AM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.Routings.Commands.Create {
    public class NewRoutingBomsDto : IRequest {
        public uint RoutingId { get; set; }
        public uint BomId { get; set; }

    }
}