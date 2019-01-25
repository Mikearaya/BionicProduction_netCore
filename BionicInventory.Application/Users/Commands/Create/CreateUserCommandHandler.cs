/*
 * @CreateTime: Jan 25, 2019 9:06 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 25, 2019 9:12 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using BionicInventory.Application.Models;
using BionicInventory.Application.Users.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BionicInventory.Application.Users.Commands.Create {
    public class CreateUserCommandHandler : IRequestHandler<NewUserModel, string> {
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateUserCommandHandler (
            UserManager<ApplicationUser> userManager
        ) {
            _userManager = userManager;
        }

        public async Task<string> Handle (NewUserModel request, CancellationToken cancellationToken) {
            var userModel = new ApplicationUser () {
                UserName = request.userName,
                PasswordHash = request.password,
            };
            var result = await _userManager.CreateAsync (userModel, request.password);

            if (result.Succeeded) {
                return userModel.Id;
            }

            throw new Exception (result.Errors.ToString ());
        }
    }
}