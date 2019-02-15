/*
 * @CreateTime: Feb 15, 2019 8:41 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 15, 2019 8:44 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.Stocks.Shipments.Models {
    public class DeletedShipmentDto : IRequest {
        public uint Id { get; set; }
    }
}