/*
 * @CreateTime: Jan 9, 2019 1:44 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 26, 2019 7:53 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BionicInventory.API.Commons {
    public class DynamicAuthorizationFilter : IAsyncAuthorizationFilter {
        private readonly IInventoryDatabaseService _database;

        public DynamicAuthorizationFilter (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task OnAuthorizationAsync (AuthorizationFilterContext context) {

            if (!IsProtectedAction (context)) {
                return;
            }

            if (!IsUserAuthenticated (context)) {
                context.Result = new UnauthorizedResult ();
                return;
            }

            var actionId = GetActionId (context);
            var userName = context.HttpContext.User.Identity.Name;
            var roles = await (from user in _database.Users join userRole in _database.UserRoles on user.Id equals userRole.UserId join role in _database.Roles on userRole.RoleId equals role.Id where user.UserName == "appdiv8"
                    select role
                )
                .ToListAsync ();

            foreach (var role in roles) {
                if (role.Access == null) {
                    continue;
                }

                var accessList = JsonConvert.DeserializeObject<IEnumerable<MvcControllerInfo>> (role.Access);
                if (accessList.SelectMany (c => c.Actions).Any (a => a.id.Trim ().ToLower () == $"{actionId.Trim().ToLower()}")) {

                    return;
                }
            }

            context.Result = new ForbidResult ();
        }

        private bool IsProtectedAction (AuthorizationFilterContext context) {
            if (context.Filters.Any (item => item is IAllowAnonymousFilter))
                return false;

            var controllerActionDescriptor = (ControllerActionDescriptor) context.ActionDescriptor;
            var controllerTypeInfo = controllerActionDescriptor.ControllerTypeInfo;
            var actionMethodInfo = controllerActionDescriptor.MethodInfo;

            var authorizeAttribute = controllerTypeInfo.GetCustomAttribute<AuthorizeAttribute> ();
            if (authorizeAttribute != null)
                return true;

            authorizeAttribute = actionMethodInfo.GetCustomAttribute<AuthorizeAttribute> ();
            if (authorizeAttribute != null)
                return true;

            return false;
        }

        private bool IsUserAuthenticated (AuthorizationFilterContext context) {
            return context.HttpContext.User.Identity.IsAuthenticated;
        }

        private string GetActionId (AuthorizationFilterContext context) {

            var controllerActionDescriptor = (ControllerActionDescriptor) context.ActionDescriptor;
            var area = controllerActionDescriptor.ControllerTypeInfo.
            GetCustomAttribute<AreaAttribute> ()?.RouteValue;
            var controller = controllerActionDescriptor.ControllerName;
            var action = controllerActionDescriptor.ActionName;

            return $"{controller}:{action}";
        }
    }
}