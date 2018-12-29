using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.Inventory.StockBatchs.Models {
    public class UpdatedStockBatchDto : IRequest {
        public uint Id { get; set; }

        [Required]
        public string status { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}