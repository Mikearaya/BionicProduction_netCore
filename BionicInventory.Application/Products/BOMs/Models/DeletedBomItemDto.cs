/*
 * @CreateTime: Dec 4, 2018 10:31 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 4, 2018 10:31 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.Products.BOMs.Models {
    public class DeletedBomItemDto : IRequest {
        public uint Id { get; set; }
    }
}