/*
 * @CreateTime: Dec 4, 2018 9:51 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 4, 2018 10:00 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.Products.BOMs.Models {
    public class NewBomDto : IRequest {
        [Required]
        public string Name { get; set; }

        [Required]
        public uint ItemId { get; set; }
        public sbyte? Active { get; set; }

        public List<NewBomItemDto> BomItems { get; set; } = new List<NewBomItemDto> ();
    }
}