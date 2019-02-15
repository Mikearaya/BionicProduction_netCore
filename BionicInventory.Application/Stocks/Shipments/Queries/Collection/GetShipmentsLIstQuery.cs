/*
 * @CreateTime: Feb 15, 2019 9:22 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 15, 2019 9:23 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Stocks.Shipments.Models;
using MediatR;

namespace BionicInventory.Application.Stocks.Shipments.Queries.Collection {
    public class GetShipmentsLIstQuery : IRequest<IEnumerable<ShipmentsListModel>> {

    }
}