/*
 * @CreateTime: Jan 15, 2019 12:08 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 15, 2019 12:21 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Products.Models;
using MediatR;

namespace BionicInventory.Application.Products.Queries {
    public class GetVendorItemsList : IRequest<IEnumerable<VendorItemViewModel>> {
        public uint VendorId { get; set; }
    }
}