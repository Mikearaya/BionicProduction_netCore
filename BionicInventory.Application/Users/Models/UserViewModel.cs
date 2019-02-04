/*
 * @CreateTime: Jan 17, 2019 11:43 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 27, 2019 7:26 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using BionicInventory.Domain.Identity;

namespace BionicInventory.Application.Users.Models {
    public class UserViewModel {
        public string userName { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string id { get; set; }
        public string role { get; set; }
        public string roleId { get; set; }

        public static Expression<Func<ApplicationUser, UserViewModel>> Projection {

            get {
                return user => new UserViewModel () {
                    userName = user.UserName,
                    phoneNumber = user.PhoneNumber,
                    email = user.Email,
                    id = user.Id,
                };
            }

        }

        public static UserViewModel Create (ApplicationUser user) {
            return Projection.Compile ().Invoke (user);
        }
    }
}