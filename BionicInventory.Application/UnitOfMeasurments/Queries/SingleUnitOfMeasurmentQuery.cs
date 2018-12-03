using MediatR;

namespace BionicInventory.Application.UnitOfMeasurments.Queries {
    public class SingleUnitOfMeasurmentQuery : IRequest<UnitOfMeasurmentView> {
        public uint Id { get; set; }
    }
}