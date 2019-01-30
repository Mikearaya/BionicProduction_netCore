/*
 * @CreateTime: Jan 9, 2019 7:40 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 8:36 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.Stocks.StockLots.Commands.Create {
    public class StockLotMovementDto : IRequest<uint> {
        public uint LotId { get; set; }
        public float Quantity { get; set; }
        public uint newStorageId { get; set; }
    }
}