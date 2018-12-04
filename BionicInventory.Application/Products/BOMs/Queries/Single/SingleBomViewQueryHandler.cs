/*
 * @CreateTime: Dec 4, 2018 11:45 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 4, 2018 11:52 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Products.BOMs.Queries.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Items.BOMs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Products.BOMs.Queries.Single {
    public class SingleBomViewQueryHandler : IRequestHandler<SingleBomViewQuery, BomView> {
        private readonly IInventoryDatabaseService _database;

        public SingleBomViewQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<BomView> Handle (SingleBomViewQuery request, CancellationToken cancellationToken) {

            var bom = await _database.Bom
                .Where (b => b.Id == request.Id)
                .Select (BomView.Projection)
                .FirstOrDefaultAsync ();

            if (bom == null) {
                throw new NotFoundException (nameof (Bom), request.Id);
            }

            return bom;
        }

    }
}