/*
 * @CreateTime: Jan 19, 2019 3:43 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 27, 2019 7:15 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;
using BionicInventory.Application.Users.Models;
using BionicInventory.Domain.Identity;
using MediatR;

namespace BionicInventory.Application.Models {
    public class AuthenticationQuery : IRequest<UserViewModel> {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        public bool RemindeMe { get; set; }
    }
}