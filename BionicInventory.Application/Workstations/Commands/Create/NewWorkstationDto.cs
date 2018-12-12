/*
 * @CreateTime: Dec 9, 2018 11:53 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2018 3:23 AM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.Workstations.Commands.Create {
    public class NewWorkstationDto : IRequest {

        [Required]
        public string Title { get; set; }

        public int? instances { get; set; } = 1;
        public double? HourlyRate { get; set; }
        public double? WorkingHours { get; set; }
        public double? HolidayHours { get; set; }
        public string Color { get; set; }
        public sbyte? IsActive { get; set; }
        public uint? Productivity { get; set; }
        public uint GroupId { get; set; }
        public uint? MaintenanceItems { get; set; }
        public float? MaintenanceHours { get; set; }

    }
}