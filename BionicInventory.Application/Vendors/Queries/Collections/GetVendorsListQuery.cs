/*
 * @CreateTime: Dec 23, 2018 11:26 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 24, 2018 8:48 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Vendors.Models;
using MediatR;

namespace BionicInventory.Application.Vendors.Queries.Collections {
    public class GetVendorsListQuery : IRequest<IEnumerable<VendorView>> {

    }
}