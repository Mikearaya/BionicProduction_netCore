/*
 * @CreateTime: Dec 30, 2018 8:11 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 30, 2018 8:29 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Inventory.StockBatchs.Models;
using MediatR;

namespace BionicInventory.Application.Inventory.StockBatchs.Queries.Single {
    public class GetStockBatchDetailViewQuery : IRequest<StockBatchDetailView> {
        public uint Id { get; set; }
    }
}