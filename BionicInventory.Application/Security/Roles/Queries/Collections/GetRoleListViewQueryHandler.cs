/*
 * @CreateTime: Jan 25, 2019 11:30 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 25, 2019 11:44 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicInventory.Application.Security.Roles.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Security.Roles.Queries.Collections {
    public class GetRoleListViewQueryHandler : IRequestHandler<GetRoleListViewQuery, IEnumerable<RoleViewModel>> {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public GetRoleListViewQueryHandler (RoleManager<ApplicationRole> roleManager) {
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<RoleViewModel>> Handle (GetRoleListViewQuery request, CancellationToken cancellationToken) {
            return await _roleManager.Roles
                .Select (RoleViewModel.Projection)
                .ToListAsync ();
        }
    }
}