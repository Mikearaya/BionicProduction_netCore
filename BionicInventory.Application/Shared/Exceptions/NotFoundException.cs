/*
 * @CreateTime: Dec 2, 2018 6:43 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 2, 2018 6:43 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.Shared.Exceptions {
    public class NotFoundException : Exception {
        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException (string name, object key) : base ($"Entity \"{name}\" ({key}) was not found.") { }

    }
}