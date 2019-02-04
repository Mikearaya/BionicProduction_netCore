/*
 * @CreateTime: Feb 3, 2019 8:44 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 3, 2019 8:52 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Users.Models;
using BionicInventory.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BionicInventory.Application.Users.Commands.Update {
    public class UpdatePasswordCommandHandler : IRequestHandler<PasswordUpdateDto, Unit> {
        private readonly UserManager<ApplicationUser> _userManager;

        public UpdatePasswordCommandHandler (UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }

        public async Task<Unit> Handle (PasswordUpdateDto request, CancellationToken cancellationToken) {
            var user = await _userManager.FindByIdAsync (request.Id);

            if (user == null) {
                throw new NotFoundException ("User", request.Id);
            }

            var result = await _userManager.ChangePasswordAsync (user, request.CurrentPassword, request.NewPassword);

            if (!result.Succeeded) {
                throw new Exception (result.Errors.ToString ());
            }
            return Unit.Value;;

        }
    }
}