/*
 * @CreateTime: Jan 7, 2019 7:21 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 7, 2019 7:22 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.Inventory.StockBatchs.Commands.Create {
    public class InventoryAdjustmentDto : IRequest {
        public uint ItemId { get; set; }
        public float NewQuantity { get; set; }
    }
}