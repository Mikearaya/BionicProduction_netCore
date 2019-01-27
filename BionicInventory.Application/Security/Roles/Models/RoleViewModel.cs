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
using BionicInventory.Domain.Identity;

namespace BionicInventory.Application.Security.Roles.Models {
    public class RoleViewModel {
        public string id { get; set; }
        public string name { get; set; }
        public string access { get; set; }

        public static Expression<Func<ApplicationRole, RoleViewModel>> Projection {
            get {
                return role => new RoleViewModel () {
                    id = role.Id,
                    name = role.Name,
                    access = role.Access

                };
            }
        }
    }
}