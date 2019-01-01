/*
 * @CreateTime: Jan 1, 2019 9:15 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 1, 2019 11:07 PM
 * @Description: Modify Here, Please 
 */

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.Inventory.WriteOffs.Models {
    public class NewWriteOffDto : IRequest<uint> {
        public NewWriteOffDto () {
            WriteOffBatchs = new List<WriteOffItemDto> ();
        }
        public uint ItemId { get; set; }

        [Required]
        public string Status { get; set; }

        public string Note { get; set; }

        [Required]
        public string Type { get; set; }

        public IEnumerable<WriteOffItemDto> WriteOffBatchs { get; set; }
    }
}