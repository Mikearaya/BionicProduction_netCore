/*
 * @CreateTime: Dec 31, 2018 11:45 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 31, 2018 11:45 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.Procurments.PurchaseOrders.Models {
    public class DeletedPurchaseOrderDto : IRequest {
        public uint Id { get; set; }
    }
}