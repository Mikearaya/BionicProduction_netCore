/*
 * @CreateTime: Jan 25, 2019 8:27 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 25, 2019 9:10 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.Users.Models {
    public class NewUserModel : IRequest<string> {
        [Required]
        public string userName { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string role { get; set; }
    }
}