/*
 * @CreateTime: Jan 4, 2019 9:39 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 25, 2019 11:42 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using BionicInventory.Application.Models;

namespace BionicInventory.Application.Security.Roles.Models {
    public class RoleViewModel {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Access { get; set; }

        public static Expression<Func<ApplicationRole, RoleViewModel>> Projection {
            get {
                return role => new RoleViewModel () {
                    Id = role.Id,
                    Name = role.Name,
                    Access = role.Access

                };
            }
        }
    }
}