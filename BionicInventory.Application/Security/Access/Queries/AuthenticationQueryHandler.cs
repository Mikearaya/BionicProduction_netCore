/*
 * @CreateTime: Jan 27, 2019 7:14 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 27, 2019 7:27 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using BionicInventory.Application.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Users.Models;
using BionicInventory.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BionicInventory.Application.Security.Access.Queries {
    public class AuthenticationQueryHandler : IRequestHandler<AuthenticationQuery, UserViewModel> {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthenticationQueryHandler (UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }
        public async Task<UserViewModel> Handle (AuthenticationQuery request, CancellationToken cancellationToken) {
            var user = await _userManager.FindByNameAsync (request.UserName);

            if (user != null && await _userManager.CheckPasswordAsync (user, request.Password)) {
                return UserViewModel.Create (user);
            }
            throw new NotFoundException ("Username or password not correct");

        }
    }
}