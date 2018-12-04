/*
 * @CreateTime: Dec 4, 2018 10:41 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 4, 2018 10:47 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.Products.BOMs.Models {
    public class UpdatedBomDto : IRequest {
        public uint Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public uint ItemId { get; set; }
        public sbyte? Active { get; set; }
        public List<UpdatedBomItemDto> BomItems { get; set; } = new List<UpdatedBomItemDto> ();
    }
}