using MediatR;

namespace BionicInventory.Application.UnitOfMeasurments.Commands.Delete {
    public class DeletedUnitOfMeasurmentDto : IRequest {
        public uint Id { get; set; }
    }
}