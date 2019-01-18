/*
 * @CreateTime: Jan 9, 2019 7:40 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 9, 2019 7:59 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Inventory.StockBatchs.Models;
using MediatR;

namespace BionicInventory.Application.Inventory.StockBatchs.Commands.Create {
    public class StockLotMovementDto : IRequest<uint> {
        public uint LotId { get; set; }
        public float Quantity { get; set; }
        public uint newStorageId { get; set; }
    }
}