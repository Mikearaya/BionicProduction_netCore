/*
 * @CreateTime: Nov 27, 2018 3:27 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 27, 2018 3:27 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;

namespace BionicInventory.Domain.Customers.PhoneNumbers {
    public class PhoneNumber {
        public uint Id { get; set; }
        public uint ClientId { get; set; }
        public string Number { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string Type { get; set; }
        public Customer Client { get; set; }
    }
}