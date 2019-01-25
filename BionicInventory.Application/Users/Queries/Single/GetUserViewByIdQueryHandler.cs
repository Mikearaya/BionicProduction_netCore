/*
 * @CreateTime: Jan 25, 2019 9:42 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 25, 2019 9:45 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Users.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Users.Queries.Single {
    public class GetUserViewByIdQueryHandler : IRequestHandler<GetUserViewByIdQuery, UserViewModel> {
        private readonly UserManager<ApplicationUser> _userManager;

        public GetUserViewByIdQueryHandler (UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }

        public async Task<UserViewModel> Handle (GetUserViewByIdQuery request, CancellationToken cancellationToken) {
            var user = await _userManager.Users
                .Select (UserViewModel.Projection)
                .FirstOrDefaultAsync (u => u.id == request.Id);

            if (user == null) {
                throw new NotFoundException ("User", request.Id);
            }

            return user;
        }
    }
}