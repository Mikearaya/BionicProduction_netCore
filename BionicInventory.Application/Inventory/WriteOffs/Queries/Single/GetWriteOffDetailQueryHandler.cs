/*
 * @CreateTime: Jan 1, 2019 10:03 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 1, 2019 10:06 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Inventory.WriteOffs.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicProduction.Domain.WriteOffs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Inventory.WriteOffs.Queries.Single {
    public class GetWriteOffDetailQueryHandler : IRequestHandler<GetWriteOffDetailQuery, WriteOffDetailView> {
        private readonly IInventoryDatabaseService _database;

        public GetWriteOffDetailQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<WriteOffDetailView> Handle (GetWriteOffDetailQuery request, CancellationToken cancellationToken) {
            var writeOff = await _database.WriteOff
                .Where (w => w.Id == request.Id)
                .Select (WriteOffDetailView.Projection)                
                .FirstOrDefaultAsync ();

            if (writeOff == null) {
                throw new NotFoundException (nameof (WriteOff), request.Id);
            }

            return writeOff;
        }
    }
}