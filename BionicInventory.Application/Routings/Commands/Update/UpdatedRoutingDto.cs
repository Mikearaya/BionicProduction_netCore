/*
 * @CreateTime: Dec 16, 2018 10:59 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 16, 2018 11:58 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.Routings.Commands.Update {
    public class UpdatedRoutingDto : IRequest {
        public uint Id { get; set; }
        public uint ItemId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Note { get; set; }
        public float? FixedCost { get; set; }
        public float? VariableCost { get; set; }
        public uint? Quantity { get; set; }

        public IList<UpdatedRoutingOperationDto> Operations { get; set; } = new List<UpdatedRoutingOperationDto> ();
        public IList<UpdatedRoutingBomsDto> Boms { get; set; } = new List<UpdatedRoutingBomsDto> ();

    }
}