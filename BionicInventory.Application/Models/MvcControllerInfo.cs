/*
 * @CreateTime: Jan 3, 2019 2:55 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 25, 2019 8:38 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;

namespace BionicInventory.Application.Models {
    public class MvcControllerInfo {
        public string Id => $"{AreaName}:{Name}";
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string AreaName { get; set; }
        public IEnumerable<MvcActionInfo> Actions { get; set; }

        public bool Checked { get; set; }
    }
}