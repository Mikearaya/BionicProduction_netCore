using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.UnitOfMeasurments.Commands.Update {
    public class UpdatedUnitOfMeasurmentDto : IRequest {
        public uint Id { get; set; }

        [Required]
        public string Abrivation { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public sbyte? Active { get; set; }
    }
}