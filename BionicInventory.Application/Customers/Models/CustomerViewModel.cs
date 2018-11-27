/*
 * @CreateTime: Sep 15, 2018 11:38 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 27, 2018 4:01 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.Customers.Models {
    public class CustomerViewModel {
        public uint id;
        public string fullName;
        public string tin;
        public string email;
        public string type;
        public DateTime? DateAdded;
        public DateTime? DateUpdated;
    }
}