/*
 * @CreateTime: Nov 28, 2018 10:04 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 28, 2018 10:04 AM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.Shared {
    public class DuplicateTinException : Exception {
        public DuplicateTinException () {

        }

        public DuplicateTinException (string name) 
        : base (String.Format ("TIN No. {0} Already Used ", name)) {

        }
    }
}