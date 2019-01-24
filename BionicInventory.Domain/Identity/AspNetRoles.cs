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

namespace BionicInventory.Domain.Identity {
    public partial class AspNetRoles {
        public AspNetRoles () {
            AspNetRoleClaims = new HashSet<AspNetRoleClaims> ();
            AspNetUserRoles = new HashSet<AspNetUserRoles> ();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }

        public ICollection<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
    }
}