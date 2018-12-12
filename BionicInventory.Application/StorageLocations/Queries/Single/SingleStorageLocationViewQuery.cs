/*
 * @CreateTime: Dec 13, 2018 12:49 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 13, 2018 12:51 AM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.StorageLocations.Models;
using MediatR;

namespace BionicInventory.Application.StorageLocations.Queries.Single {
    public class SingleStorageLocationViewQuery : IRequest<StorageLocationView> {
        public uint Id { get; set; }
    }
}