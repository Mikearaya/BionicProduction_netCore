/*
 * @CreateTime: Jan 10, 2019 9:32 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 10, 2019 9:35 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.Shared.Exceptions {
    public class DuplicateStorageLocationMovementException : Exception {
        public DuplicateStorageLocationMovementException () { }

        public DuplicateStorageLocationMovementException (uint lotId, string storageLocation) 
        : base ($"Lot # {lotId} already has items in storage location {storageLocation}") { }
    }
}