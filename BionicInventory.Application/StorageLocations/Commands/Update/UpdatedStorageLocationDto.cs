/*
 * @CreateTime: Dec 13, 2018 12:24 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 13, 2018 12:25 AM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.StorageLocations.Commands.Update {
    public class UpdatedStorageLocationDto : IRequest {
        public uint Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Note { get; set; }
        public sbyte? Active { get; set; }
    }
}