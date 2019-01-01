/*
 * @CreateTime: Jan 1, 2019 9:43 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 1, 2019 9:46 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.Shared.Exceptions {
    public class QuantityGreaterThanAvailableException : Exception {
        public QuantityGreaterThanAvailableException (string type, double quantity, double available) : base ($" {type} specified quantity {quantity} is greater than  ({available}) Quantity.") { }
    }
}