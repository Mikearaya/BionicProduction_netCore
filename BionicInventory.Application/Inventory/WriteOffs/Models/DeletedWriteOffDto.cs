/*
 * @CreateTime: Jan 1, 2019 9:18 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 1, 2019 9:18 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.Inventory.WriteOffs.Models {
    public class DeletedWriteOffDto : IRequest {
        public uint Id { get; set; }
    }
}