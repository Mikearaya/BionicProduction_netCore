/*
 * @CreateTime: Nov 27, 2018 4:59 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 27, 2018 8:27 PM
 * @Description: Modify Here, Please 
 */
namespace BionicInventory.Application.Customers.Models.Addresses {
    public class CustomerAddressView {

        public uint id { get; set; }
        public string location { get; set; }
        public string city { get; set; }
        public string subCity { get; set; }
        public string country { get; set; }
        public string phoneNumber { get; set; }
    }

}