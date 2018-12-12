/*
 * @CreateTime: Dec 12, 2018 1:15 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2018 1:20 AM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.Workstations.Commands.Update {
    public class UpdatedWorkstationDto : IRequest {
        public uint Id { get; set; }

        [Required]
        public string Title { get; set; }
        public double? HourlyRate { get; set; }
        public double? WorkingHours { get; set; }
        public double? HolidayHours { get; set; }
        public string Color { get; set; }
        public sbyte? IsActive { get; set; }
        public float? MaintenanceHours { get; set; }
        public uint? Productivity { get; set; }
        public uint GroupId { get; set; }
        public uint? MaintenanceItems { get; set; }

    }
}