/*
 * @CreateTime: Dec 9, 2018 11:53 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 10, 2018 12:01 AM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.Workstations.Commands.Create {
    public class NewWorkstationDto : IRequest {

        [Required]
        public string Title { get; set; }
        public double? HourlyRate { get; set; } = 0;
        public uint instances { get; set; }
        public sbyte? CustomWorkingHoures { get; set; } = 0;
        public sbyte? CustomHolidays { get; set; } = 0;
        public sbyte? IsActive { get; set; } = 0;
        public string Color { get; set; } = "Blue";

    }
}