/*
 * @CreateTime: Dec 16, 2018 10:59 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 17, 2018 11:03 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.Routings.Commands.Create {
    public class NewRoutingDto : IRequest {
        public uint ItemId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Note { get; set; }
        public float? FixedCost { get; set; }
        public float? VariableCost { get; set; }
        public uint? Quantity { get; set; }

        public IEnumerable<NewRoutingOperationDto> Operations { get; set; } = new List<NewRoutingOperationDto> ();
        public IEnumerable<NewRoutingBomsDto> Boms { get; set; } = new List<NewRoutingBomsDto> ();

    }
}