/*
 * @CreateTime: Jan 25, 2019 11:10 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 25, 2019 11:20 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.Security.Roles.Models {
    public class UpdatedRoleDto : IRequest {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Access { get; set; }
    }
}