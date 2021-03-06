/*
 * @CreateTime: Jan 25, 2019 11:10 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 25, 2019 11:13 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BionicInventory.Application.Models;
using MediatR;

namespace BionicInventory.Application.Security.Roles.Models {
    public class NewRoleDto : IRequest<string> {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Access { get; set; }
    }
}