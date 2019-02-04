/*
 * @CreateTime: Jan 25, 2019 9:13 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 25, 2019 9:15 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.Users.Models {
    public class UpdatedUserDto : IRequest {
        [Required]
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}