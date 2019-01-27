/*
 * @CreateTime: Jan 25, 2019 9:16 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 25, 2019 9:21 PM
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
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Users.Commands.Update {
    public class UpdateUserCommandHandler : IRequestHandler<UpdatedUserDto> {
        private readonly UserManager<ApplicationUser> _userManager;

        public UpdateUserCommandHandler (
            UserManager<ApplicationUser> userManager
        ) {
            _userManager = userManager;
        }

        public async Task<Unit> Handle (UpdatedUserDto request, CancellationToken cancellationToken) {
            var user = await _userManager.Users
                .FirstOrDefaultAsync (u => u.Id == request.Id);

            if (user == null) {
                throw new NotFoundException ("User", request.Id);
            }

            user.UserName = request.userName;
            await _userManager.UpdateAsync (user);

            return Unit.Value;
        }
    }
}