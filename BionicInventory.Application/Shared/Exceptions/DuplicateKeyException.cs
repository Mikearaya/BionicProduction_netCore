/*
 * @CreateTime: Feb 7, 2019 2:45 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 7, 2019 2:45 AM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.Shared.Exceptions {
    public class DuplicateKeyException : Exception {
        public DuplicateKeyException () { }

        public DuplicateKeyException (string columnName, string id) : base ($" {columnName} id ({id}) already used ") { }

    }
}