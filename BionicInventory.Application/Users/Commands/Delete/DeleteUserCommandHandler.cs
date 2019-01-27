/*
 * @CreateTime: Jan 25, 2019 9:22 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 25, 2019 9:25 PM
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

namespace BionicInventory.Application.Users.Commands.Delete {
    public class DeleteUserCommandHandler : IRequestHandler<DeletedUserDto, Unit> {
        private readonly UserManager<ApplicationUser> _userManager;

        public DeleteUserCommandHandler (UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }

        public async Task<Unit> Handle (DeletedUserDto request, CancellationToken cancellationToken) {
            var user = await _userManager
                .Users
                .FirstOrDefaultAsync (u => u.Id == request.Id);

            if (user == null) {
                throw new NotFoundException ("User", request.Id);
            }

            await _userManager.DeleteAsync (user);

            return Unit.Value;
        }
    }
}