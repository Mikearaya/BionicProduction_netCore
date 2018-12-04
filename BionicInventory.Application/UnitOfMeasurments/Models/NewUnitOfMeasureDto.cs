/*
 * @CreateTime: Dec 4, 2018 8:02 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 4, 2018 8:02 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;
using BionicInventory.Domain.UnitOfMeasurments;
using MediatR;

namespace BionicInventory.Application.UnitOfMeasurments.Models {
    public class NewUnitOfMeasureDto : IRequest {

        [Required]
        public string Abrivation { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public sbyte? Active { get; set; }
    }
}