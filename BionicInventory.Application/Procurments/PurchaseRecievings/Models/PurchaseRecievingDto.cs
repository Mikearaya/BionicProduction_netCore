/*
 * @CreateTime: Feb 19, 2019 7:31 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 19, 2019 7:48 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using MediatR;

namespace BionicInventory.Application.Procurments.PurchaseRecievings.Models {
    public class PurchaseRecievingDto : IRequest<uint> {
        public uint PurchaseOrderId { get; set; }
        public IEnumerable<PurchaseRecievingItemDto> RecievedItems = new List<PurchaseRecievingItemDto> ();
    }
}