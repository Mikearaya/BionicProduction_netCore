/*
 * @CreateTime: Jan 24, 2019 8:16 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 24, 2019 8:16 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BionicInventory.Domain.Identity {
    public partial class ApplicationRole : IdentityRole<string> {
        public ApplicationRole () {
            AspNetRoleClaims = new HashSet<AspNetRoleClaims> ();
            AspNetUserRoles = new HashSet<AspNetUserRoles> ();
        }
        public string Access { get; set; }
        public ICollection<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
    }
}