/*
 * @CreateTime: Dec 16, 2018 11:34 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 16, 2018 11:35 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.Routings.Commands.Create {
    public class NewRoutingOperationDto {
        public uint WorkstationId { get; set; }

        [Required]
        public string Operation { get; set; }
        public double? FixedCost { get; set; }
        public double? VariableCost { get; set; }
        public float? FixedTime { get; set; }
        public float? VariableTime { get; set; }
        public int Quantity { get; set; }

    }
}