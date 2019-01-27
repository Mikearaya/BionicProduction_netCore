/*
 * @CreateTime: Jan 25, 2019 11:19 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 25, 2019 11:23 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using BionicInventory.Application.Security.Roles.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Security.Roles.Commands.Update {
    public class UpdateRoleCommandHandler : IRequestHandler<UpdatedRoleDto, Unit> {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UpdateRoleCommandHandler (RoleManager<ApplicationRole> roleManager) {
            _roleManager = roleManager;
        }

        public async Task<Unit> Handle (UpdatedRoleDto request, CancellationToken cancellationToken) {
            var role = await _roleManager.Roles
                .FirstOrDefaultAsync (r => r.Id == request.Id);

            if (role == null) {
                throw new NotFoundException ("Role", request.Id);
            }

            role.Name = request.Name;
            role.Access = request.Access;

            await _roleManager.UpdateAsync (role);

            return Unit.Value;
        }
    }
}