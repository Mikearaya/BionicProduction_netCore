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
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Models;
using BionicInventory.Application.Security.Roles.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Users.Models;
using BionicInventory.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Users.Commands.Create {
    public class CreateUserCommandHandler : IRequestHandler<NewUserDto, string> {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IInventoryDatabaseService _database;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public CreateUserCommandHandler (
            UserManager<ApplicationUser> userManager,
            IInventoryDatabaseService database,
            RoleManager<ApplicationRole> roleManager
        ) {
            _userManager = userManager;
            _database = database;
            _roleManager = roleManager;
        }

        public async Task<string> Handle (NewUserDto request, CancellationToken cancellationToken) {
            var role = await _roleManager.Roles
                .FirstOrDefaultAsync (r => r.Id == request.roleId);

            if (role == null) {
                throw new NotFoundException ("User role", request.roleId);
            }

            var userModel = new ApplicationUser () {
                UserName = request.userName,
                PasswordHash = "000000",
                
            };
            var result = await _userManager.CreateAsync (userModel, "000000");

            if (result.Succeeded) {
                _database.UserRoles.Add (new AspNetUserRoles () {
                    UserId = userModel.Id,
                        RoleId = role.Id
                });
                await _database.SaveAsync ();

                return userModel.Id;
            }

            throw new Exception (result.Errors.ToString ());
        }
    }
}