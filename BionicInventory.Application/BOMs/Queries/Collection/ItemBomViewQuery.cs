/*
 * @CreateTime: Dec 5, 2018 9:34 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 5, 2018 9:34 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Products.BOMs.Queries.Models;
using MediatR;

namespace BionicInventory.Application.Products.BOMs.Queries.Collection {
    public class ItemBomViewQuery : IRequest<IEnumerable<BomView>> {

        public uint ItemId { get; set; }

    }
}