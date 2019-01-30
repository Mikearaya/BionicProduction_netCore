/*
 * @CreateTime: Jan 7, 2019 7:21 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 8:36 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.Stocks.StockLots.Commands.Create {
    public class InventoryAdjustmentDto : IRequest {
        public uint ItemId { get; set; }
        public float NewQuantity { get; set; }
    }
}