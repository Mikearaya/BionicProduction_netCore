/*
 * @CreateTime: Jan 24, 2019 8:17 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 24, 2019 8:17 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BionicInventory.Domain.Identity {
    public partial class ApplicationUser : IdentityUser<string> {
        public ApplicationUser () {
            AspNetUserClaims = new HashSet<AspNetUserClaims> ();
            AspNetUserLogins = new HashSet<AspNetUserLogins> ();
            AspNetUserRoles = new HashSet<AspNetUserRoles> ();
            AspNetUserTokens = new HashSet<AspNetUserTokens> ();
        }

        public ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        public ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        public ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public ICollection<AspNetUserTokens> AspNetUserTokens { get; set; }
    }
}