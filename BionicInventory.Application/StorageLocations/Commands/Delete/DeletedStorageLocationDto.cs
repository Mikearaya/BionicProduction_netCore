/*
 * @CreateTime: Dec 13, 2018 12:30 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 13, 2018 12:31 AM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.StorageLocations.Commands.Delete {
    public class DeletedStorageLocationDto : IRequest {
        public uint Id { get; set; }

    }
}