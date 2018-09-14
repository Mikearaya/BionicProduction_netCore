/*
 * @CreateTime: Sep 14, 2018 10:17 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 14, 2018 11:32 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.FinishedProducts.Models {
    public class FinishedProductsViewModel {
        public uint id;
        public uint orderId;
        public int quantity;
        public string submittedBy;
        public string recievedBy;
        public DateTime dateAdded;
        public DateTime dateUpdated;
    }
}