/*
 * @CreateTime: Jan 1, 2019 10:01 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 4, 2019 11:16 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Inventory.WriteOffs.Models;
using MediatR;

namespace BionicInventory.Application.Inventory.WriteOffs.Queries.Collections {
    public class GetWriteOffsListQuery : IRequest<IEnumerable<WriteOffListView>> {

    }
}