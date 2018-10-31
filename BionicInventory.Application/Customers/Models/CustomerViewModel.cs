/*
 * @CreateTime: Sep 15, 2018 11:38 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 15, 2018 11:38 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.Customers.Models {
    public class CustomerViewModel {
        public uint id;
        public string firstName;
        public string lastName;
        public string tin;
        public string email;
        public string type;
        public string mainPhone;
        public DateTime? DateAdded;
        public DateTime? DateUpdated;
    }
}