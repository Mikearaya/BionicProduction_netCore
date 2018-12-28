/*
 * @CreateTime: Dec 28, 2018 10:28 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 28, 2018 10:29 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.Shared.Exceptions {
    public class InequalMasterDetailQuantityException : Exception {
        public InequalMasterDetailQuantityException () { }

        public InequalMasterDetailQuantityException (string type, double master, double detail)
        :base($"Sum of total subset {detail} not equal to superset sum {master} for {type} ") {

        }
    }
}