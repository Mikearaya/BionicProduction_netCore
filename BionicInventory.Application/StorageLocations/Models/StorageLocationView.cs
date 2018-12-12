/*
 * @CreateTime: Dec 13, 2018 12:39 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 13, 2018 12:42 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using BionicInventory.Domain.Storages;

namespace BionicInventory.Application.StorageLocations.Models {
    public class StorageLocationView {
        public uint id { get; set; }
        public string name { get; set; }
        public string note { get; set; }
        public bool active { get; set; }
        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }

        public static Expression<Func<StorageLocation, StorageLocationView>> Projection {

            get {
                return storage => new StorageLocationView {
                    id = storage.Id,
                    name = storage.Name,
                    note = storage.Note,
                    active = (storage.Active != 0) ? true : false,
                    dateAdded = storage.DateAdded,
                    dateUpdated = storage.DateUpdated,
                };
            }

        }

        public static StorageLocationView Create (StorageLocation storageLocation) {
            return Projection.Compile ().Invoke (storageLocation);
        }

    }
}