/*
 * @CreateTime: Jan 1, 2019 10:01 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 9:25 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Stocks.WriteOffs.Models;
using MediatR;

namespace BionicInventory.Application.Stocks.WriteOffs.Queries.Collections {
    public class GetWriteOffsListQuery : IRequest<IEnumerable<WriteOffListView>> {

    }
}