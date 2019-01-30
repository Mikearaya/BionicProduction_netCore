/*
 * @CreateTime: Dec 27, 2018 11:45 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 8:37 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.Stocks.StockLots.Models {
    public class DeletedStockBatchDto : IRequest {
        public uint Id { get; set; }
    }
}