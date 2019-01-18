/*
 * @CreateTime: Dec 23, 2018 11:04 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 23, 2018 11:04 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.Shared.Exceptions {
    public class DuplicateTinNumberException : Exception {
        public DuplicateTinNumberException () { }

        public DuplicateTinNumberException (string tin) : base (String.Format ("TIN No. {0} Already Used ", tin)) {

        }
    }
}