/*
 * @CreateTime: Jan 3, 2019 2:54 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 25, 2019 8:39 PM
 * @Description: Modify Here, Please 
 */
namespace BionicInventory.Application.Models {
    public class MvcActionInfo {
        public string id => $"{controllerId}{name}";
        public string name { get; set; }
        public string displayName { get; set; }
        public string controllerId { get; set; }
        public bool selected { get; set; }
        public string type { get; set; }
    }
}