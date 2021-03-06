/*
 * @CreateTime: Dec 29, 2018 12:19 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 8:38 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.Stocks.StockLots.Models {
    public class StockMovementDto : IRequest<uint> {
        public uint batchId { get; set; }
        public uint previousStorage { get; set; }
        public float quantity { get; set; }
        public uint newStorage { get; set; }

    }
}