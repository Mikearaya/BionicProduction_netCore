/*
 * @CreateTime: Jan 4, 2019 7:10 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 9:24 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Stocks.WriteOffs.Models;
using MediatR;

namespace BionicInventory.Application.Stocks.WriteOffs.Queries.Single {
    public class GetItemWriteOffsByIdQuery : IRequest<IEnumerable<WriteOffItemListView>> {
        public uint ItemId { get; set; }
    }
}