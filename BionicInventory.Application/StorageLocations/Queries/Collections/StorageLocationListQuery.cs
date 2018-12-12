using System.Collections.Generic;
using BionicInventory.Application.StorageLocations.Models;
using MediatR;

namespace BionicInventory.Application.StorageLocations.Queries.Collections {
    public class StorageLocationListQuery : IRequest<IEnumerable<StorageLocationView>> {

    }
}