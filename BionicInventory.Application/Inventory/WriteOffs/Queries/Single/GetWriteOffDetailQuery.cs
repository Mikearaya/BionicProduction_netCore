/*
 * @CreateTime: Jan 1, 2019 10:01 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 1, 2019 10:05 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Inventory.WriteOffs.Models;
using MediatR;

namespace BionicInventory.Application.Inventory.WriteOffs.Queries.Single {
    public class GetWriteOffDetailQuery : IRequest<WriteOffDetailView> {
        public uint Id { get; set; }
    }
}