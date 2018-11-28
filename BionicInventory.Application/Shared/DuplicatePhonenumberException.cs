/*
 * @CreateTime: Nov 28, 2018 10:07 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 28, 2018 10:07 AM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.Shared {
    public class DuplicatePhonenumberException : Exception {

        public DuplicatePhonenumberException () {

        }

        public DuplicatePhonenumberException (string phone) 
        : base (String.Format ("Phone number  {0} Already in Use", phone)) {

        }
    }
}