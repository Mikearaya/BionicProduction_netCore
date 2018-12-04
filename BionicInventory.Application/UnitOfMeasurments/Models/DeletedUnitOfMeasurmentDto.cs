/*
 * @CreateTime: Dec 4, 2018 7:53 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 4, 2018 7:53 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.UnitOfMeasurments.Models {
    public class DeletedUnitOfMeasurmentDto : IRequest {
        public uint Id { get; set; }
    }
}