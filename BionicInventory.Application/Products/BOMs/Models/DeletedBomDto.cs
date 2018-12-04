/*
 * @CreateTime: Dec 4, 2018 10:24 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 4, 2018 10:25 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.Products.BOMs.Models {
    public class DeletedBomDto : IRequest {
        public uint Id { get; set; }

    }
}