/*
 * @CreateTime: Jan 30, 2019 7:42 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 7:42 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Stocks.Items.Models;
using MediatR;

namespace BionicInventory.Application.Stocks.Items.Queries.Single {
    public class GetItemByIdQuery : IRequest<ItemView> {
        public uint Id { get; set; }
    }
}