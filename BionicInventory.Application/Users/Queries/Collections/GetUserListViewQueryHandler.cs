/*
 * @CreateTime: Jan 25, 2019 9:37 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 25, 2019 9:40 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicInventory.Application.Users.Models;
using BionicInventory.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Users.Queries.Collections {
    public class GetUserListViewQueryHandler : IRequestHandler<GetUsersListViewQuery, IEnumerable<UserViewModel>> {
        private readonly UserManager<ApplicationUser> _userManger;

        public GetUserListViewQueryHandler (
            UserManager<ApplicationUser> userManager
        ) {
            _userManger = userManager;
        }

        public async Task<IEnumerable<UserViewModel>> Handle (GetUsersListViewQuery request, CancellationToken cancellationToken) {
            return await _userManger.Users
                .Select (UserViewModel.Projection)
                .ToListAsync ();
        }
    }
}