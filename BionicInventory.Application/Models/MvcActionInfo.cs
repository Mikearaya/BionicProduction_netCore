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
        public string Id => $"{ControllerId}:{Name}";
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string ControllerId { get; set; }

        public string type { get; set; }

        public bool Checked { get; set; }
    }
}