/*
 * @CreateTime: Jan 1, 2019 9:18 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 9:21 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.Stocks.WriteOffs.Models {
    public class DeletedWriteOffDto : IRequest {
        public uint Id { get; set; }
    }
}