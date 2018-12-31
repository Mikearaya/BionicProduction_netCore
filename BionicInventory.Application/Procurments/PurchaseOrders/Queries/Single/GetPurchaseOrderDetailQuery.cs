/*
 * @CreateTime: Jan 1, 2019 12:18 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 1, 2019 12:19 AM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Procurments.PurchaseOrders.Models;
using MediatR;

namespace BionicInventory.Application.Procurments.PurchaseOrders.Queries.Single {
    public class GetPurchaseOrderDetailQuery : IRequest<PurchaseOrderDetailView> {
        public uint Id { get; set; }
    }
}