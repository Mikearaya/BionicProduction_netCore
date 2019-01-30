/*
 * @CreateTime: Jan 30, 2019 7:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 7:33 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.Stocks.Items.Models {
    public class DeletedItemDto : IRequest {
        public uint Id { get; set; }
    }
}