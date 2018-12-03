/*
 * @CreateTime: Dec 4, 2018 12:45 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 4, 2018 12:45 AM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.UnitOfMeasurments.Commands.Update {
    public class UpdatedUnitOfMeasurmentDto : IRequest {
        public uint Id { get; set; }

        [Required]
        public string Abrivation { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public sbyte? Active { get; set; }
    }
}