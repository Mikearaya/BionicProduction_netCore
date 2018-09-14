/*
 * @CreateTime: Sep 14, 2018 10:17 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 15, 2018 12:28 AM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.FinishedProducts.Models {
    public class FinishedProductsViewModel {
        public uint id;
        public uint orderId;
        public int quantity;
        public uint submittedBy;
        public uint recievedBy;
        public string submitter;
        public string reciever;
        public DateTime dateAdded;
        public DateTime dateUpdated;
    }
}