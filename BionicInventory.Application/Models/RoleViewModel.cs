/*
 * @CreateTime: Jan 4, 2019 9:39 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 25, 2019 8:38 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.Models {
    public class RoleViewModel {
        public string RoleName { get; set; }
        public IEnumerable<MvcControllerInfo> Access { get; set; }
    }
}