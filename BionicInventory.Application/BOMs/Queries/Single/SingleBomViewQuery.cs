/*
 * @CreateTime: Dec 4, 2018 11:43 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 4, 2018 11:49 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Products.BOMs.Queries.Models;
using MediatR;

namespace BionicInventory.Application.Products.BOMs.Queries.Single {
    public class SingleBomViewQuery : IRequest<BomView> {

        public uint Id { get; set; }
    }
}