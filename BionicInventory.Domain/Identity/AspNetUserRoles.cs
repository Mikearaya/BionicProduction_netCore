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
    public partial class AspNetUserRoles : IdentityUserRole<string> {

        public ApplicationRole Role { get; set; }
        public ApplicationUser User { get; set; }
    }
}