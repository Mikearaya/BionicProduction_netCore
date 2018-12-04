/*
 * @CreateTime: Dec 4, 2018 11:30 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 4, 2018 11:31 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Products.BOMs.Queries.Models;
using MediatR;

namespace BionicInventory.Application.Products.BOMs.Queries.Collection {
    public class BomViewListQuery : IRequest<IEnumerable<BomView>> {

    }
}