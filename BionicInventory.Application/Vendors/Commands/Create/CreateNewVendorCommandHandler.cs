/*
 * @CreateTime: Dec 23, 2018 11:01 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 23, 2018 11:13 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Vendors;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Vendors.Commands.Create {
    public class CreateNewVendorCommandHandler : IRequestHandler<NewVendorDto, uint> {
        private readonly IInventoryDatabaseService _database;

        public CreateNewVendorCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<uint> Handle (NewVendorDto request, CancellationToken cancellationToken) {

            if (request.TinNumber.Length > 0) {
                var tin = await _database.Vendor
                    .Where (v => v.TinNumber.ToUpper () == request.TinNumber.ToUpper ())
                    .CountAsync ();

                if (tin > 0) {
                    throw new DuplicateTinNumberException (request.TinNumber);
                }
            }
            Vendor newVendor = new Vendor () {
                Name = request.Name,
                TinNumber = request.TinNumber,
                PaymentPeriod = request.PaymentPeriod,
                LeadTime = request.LeadTime,
                PhoneNumber = request.PhoneNumber,

            };
            _database.Vendor.Add (newVendor);
            await _database.SaveAsync ();

            return newVendor.Id;

        }
    }
}