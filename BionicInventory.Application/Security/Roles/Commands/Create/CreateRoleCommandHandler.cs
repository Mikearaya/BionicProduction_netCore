/*
 * @CreateTime: Jan 25, 2019 11:13 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 25, 2019 11:19 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using BionicInventory.Application.Security.Roles.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BionicInventory.Application.Security.Roles.Commands.Create {
    public class CreateRoleCommandHandler : IRequestHandler<NewRoleDto, string> {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public CreateRoleCommandHandler (RoleManager<ApplicationRole> roleManager) {
            _roleManager = roleManager;
        }

        public async Task<string> Handle (NewRoleDto request, CancellationToken cancellationToken) {
            ApplicationRole role = new ApplicationRole () {
                Name = request.Name,
                Access = request.Access.ToString ()
            };

            var result = await _roleManager.CreateAsync (role);

            if (result.Succeeded) {
                return role.Id;
            }

            throw new Exception (result.Errors.ToString ());
        }
    }
}