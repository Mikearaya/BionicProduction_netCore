/*
 * @CreateTime: Feb 15, 2019 10:37 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 15, 2019 10:38 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Stocks.Shipments.Models;
using MediatR;

namespace BionicInventory.Application.Stocks.Shipments.Queries.Single {
    public class GetShipmentDetailQuery : IRequest<ShipmentDetailModel> {
        public uint Id { get; set; }
    }
}