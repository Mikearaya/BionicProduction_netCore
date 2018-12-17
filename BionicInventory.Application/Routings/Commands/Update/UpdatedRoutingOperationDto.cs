/*
 * @CreateTime: Dec 16, 2018 11:07 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 16, 2018 11:07 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.Routings.Commands.Update {
    public class UpdatedRoutingOperationDto {
        public uint Id { get; set; }
        public uint RoutingId { get; set; }
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