using System.ComponentModel.DataAnnotations;
using BionicInventory.Domain.UnitOfMeasurments;
using MediatR;

namespace BionicInventory.Application.UnitOfMeasurments.Commands.Create {
    public class NewUnitOfMeasureDto : IRequest {

        [Required]
        public string Abrivation { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public sbyte? Active { get; set; }
    }
}