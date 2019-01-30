/*
 * @CreateTime: Jan 1, 2019 10:01 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 9:25 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Stocks.WriteOffs.Models;
using MediatR;

namespace BionicInventory.Application.Stocks.WriteOffs.Queries.Single {
    public class GetWriteOffDetailQuery : IRequest<WriteOffDetailView> {
        public uint Id { get; set; }
    }
}