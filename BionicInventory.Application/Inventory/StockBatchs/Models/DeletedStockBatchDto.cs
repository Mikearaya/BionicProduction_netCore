/*
 * @CreateTime: Dec 27, 2018 11:45 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 27, 2018 11:45 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.Inventory.StockBatchs.Models {
    public class DeletedStockBatchDto : IRequest {
        public uint Id { get; set; }
    }
}