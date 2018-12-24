/*
 * @CreateTime: Dec 24, 2018 9:02 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 24, 2018 9:02 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Vendors.Models;
using MediatR;

namespace BionicInventory.Application.Vendors.Queries.Single {
    public class GetVendorByIdQuery : IRequest<VendorView> {
        public uint Id { get; set; }
    }
}