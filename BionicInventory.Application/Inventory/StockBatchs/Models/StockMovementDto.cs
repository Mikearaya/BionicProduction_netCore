/*
 * @CreateTime: Dec 29, 2018 12:19 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 29, 2018 12:24 AM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.Inventory.StockBatchs.Models {
    public class StockMovementDto : IRequest<uint> {
        public uint batchId { get; set; }
        public uint previousStorage { get; set; }
        public float quantity { get; set; }
        public uint newStorage { get; set; }

    }
}