/*
 * @CreateTime: Dec 23, 2018 10:59 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 23, 2018 10:59 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.Vendors.Commands.Delete {
    public class DeletedVendorDto : IRequest {
        public uint Id { get; set; }
    }
}