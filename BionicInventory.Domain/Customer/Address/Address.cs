/*
 * @CreateTime: Nov 27, 2018 3:06 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 27, 2018 3:06 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;

namespace BionicInventory.Domain.Customers.Addresses {
    public class Address {
        public uint Id { get; set; }
        public uint ClientId { get; set; }
        public string SubCity { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
        public Customer Client { get; set; }
    }
}