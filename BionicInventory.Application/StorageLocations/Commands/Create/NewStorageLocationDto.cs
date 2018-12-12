/*
 * @CreateTime: Dec 13, 2018 12:18 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 13, 2018 12:19 AM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.StorageLocations.Commands.Create {
    public class NewStorageLocationDto : IRequest {
        [Required]
        public string Name { get; set; }
        public string Note { get; set; }
        public sbyte? Active { get; set; }

    }
}