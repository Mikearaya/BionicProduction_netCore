/*
 * @CreateTime: Feb 7, 2019 2:51 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 7, 2019 3:02 AM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Stocks.Items.Queries.Single {
    public class IsItemCodeUniqueQueryHandler : IRequestHandler<IsItemCodeUniqueQuery, bool> {
        private readonly IInventoryDatabaseService _database;

        public IsItemCodeUniqueQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<bool> Handle (IsItemCodeUniqueQuery request, CancellationToken cancellationToken) {
            return await _database.Item
                .AnyAsync (i => i.Code.Trim ().ToUpper () != request.itemCode.Trim ().ToUpper ());
        }
    }
}