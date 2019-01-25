/*
 * @CreateTime: Jan 25, 2019 11:35 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 25, 2019 11:44 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Security.Roles.Models;
using MediatR;

namespace BionicInventory.Application.Security.Roles.Queries.Single {
    public class GetRoleByIdQuery : IRequest<RoleViewModel> {
        public string Id { get; set; }
    }
}