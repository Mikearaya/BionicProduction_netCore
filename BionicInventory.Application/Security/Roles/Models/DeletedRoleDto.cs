/*
 * @CreateTime: Jan 25, 2019 11:11 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 25, 2019 11:11 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.Security.Roles.Models {
    public class DeletedRoleDto : IRequest {
        [Required]
        public string Id { get; set; }
    }
}