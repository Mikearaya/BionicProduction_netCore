/*
 * @CreateTime: Jan 30, 2019 7:54 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 7:56 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Products.Models;
using MediatR;

namespace BionicInventory.Application.Stocks.Items.Queries.Single {
    public class GetCriticalItemByIdQuery : IRequest<CriticalItemsView> {
        public uint Id { get; set; }
    }
}