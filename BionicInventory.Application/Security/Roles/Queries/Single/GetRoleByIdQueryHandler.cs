/*
 * @CreateTime: Jan 25, 2019 11:37 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 25, 2019 11:44 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicInventory.Application.Security.Roles.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Security.Roles.Queries.Single {
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, RoleViewModel> {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public GetRoleByIdQueryHandler (RoleManager<ApplicationRole> roleManager) {
            _roleManager = roleManager;
        }

        public async Task<RoleViewModel> Handle (GetRoleByIdQuery request, CancellationToken cancellationToken) {
            var role = await _roleManager.Roles
                .Where (r => r.Id == request.Id)
                .Select (RoleViewModel.Projection)
                .FirstOrDefaultAsync ();

            if (role == null) {
                throw new NotFoundException ("Role", request.Id);
            }

            return role;
        }
    }
}