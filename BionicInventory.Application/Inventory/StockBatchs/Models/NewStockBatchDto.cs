/*
 * @CreateTime: Dec 27, 2018 11:45 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 28, 2018 12:24 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.Inventory.StockBatchs.Models {
    public class NewStockBatchDto : IRequest<uint> {
        public uint ItemId { get; set; }
        public float Quantity { get; set; }
        public float UnitCost { get; set; }
        [Required]
        public string Status { get; set; }
        public string Source {get; set;}
        public uint? PurchaseOrderId { get; set; }

        public uint? ManufactureOrderId { get; set; }

        [Required]
        public DateTime AvailableFrom { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public List<NewStockBatchStorageDto> StorageLocation { get; set; } = new List<NewStockBatchStorageDto> ();
    }
}