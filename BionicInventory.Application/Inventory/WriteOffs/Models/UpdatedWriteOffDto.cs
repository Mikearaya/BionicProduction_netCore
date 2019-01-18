/*
 * @CreateTime: Jan 1, 2019 9:18 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 1, 2019 9:56 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.Inventory.WriteOffs.Models {
    public class UpdatedWriteOffDto : IRequest {
        public UpdatedWriteOffDto () {
            WriteOffBatchs = new List<WriteOffItemDto> ();
        }

        public uint Id { get; set; }

        [Required]
        public string Status { get; set; }
        public string Note { get; set; }

        [Required]
        public string Type { get; set; }
        public IEnumerable<WriteOffItemDto> WriteOffBatchs { get; set; }

    }
}