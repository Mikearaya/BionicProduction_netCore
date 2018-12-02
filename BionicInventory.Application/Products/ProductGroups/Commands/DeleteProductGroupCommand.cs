/*
 * @CreateTime: Dec 2, 2018 6:34 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 2, 2018 6:35 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.Products.ProductGroups.Commands {
    public class DeleteProductGroupCommand : IRequest {
        public uint Id { get; set; }
    }
}