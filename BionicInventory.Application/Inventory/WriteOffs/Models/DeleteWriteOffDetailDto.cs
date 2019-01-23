/*
 * @CreateTime: Jan 23, 2019 8:54 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 23, 2019 8:54 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.Inventory.WriteOffs.Models {
    public class DeleteWriteOffDetailDto : IRequest {
        public uint WriteOffDetailId { get; set; }
    }
}