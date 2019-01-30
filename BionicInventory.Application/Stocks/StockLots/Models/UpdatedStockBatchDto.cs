/*
 * @CreateTime: Jan 30, 2019 8:38 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 8:38 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.Stocks.StockLots.Models {
    public class UpdatedStockBatchDto : IRequest {
        public uint Id { get; set; }

        [Required]
        public string status { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}