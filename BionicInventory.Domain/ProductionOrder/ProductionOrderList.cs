﻿/*
 * @CreateTime: Dec 23, 2018 9:59 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 23, 2018 10:21 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.CustomerOrders;
using BionicInventory.Domain.Employees;
using BionicInventory.Domain.FinishedProducts;
using BionicInventory.Domain.Items;
using BionicProduction.Domain.StockBatchs;

namespace BionicInventory.Domain.ProductionOrders {
    public class ProductionOrderList {
        public ProductionOrderList () {
            BookedStockBatch = new HashSet<BookedStockBatch> ();
            FinishedProduct = new HashSet<FinishedProduct> ();
            StockBatch = new HashSet<StockBatch> ();
        }

        public uint Id { get; set; }
        public uint ItemId { get; set; }
        public uint Quantity { get; set; }
        public float CostPerItem { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime DueDate { get; set; }
        public uint? PurchaseOrderId { get; set; }
        public DateTime Start { get; set; }
        public uint OrderedBy { get; set; }
        public string Description { get; set; }

        public virtual Item Item { get; set; }
        public virtual Employee OrderedByNavigation { get; set; }
        public virtual ICollection<BookedStockBatch> BookedStockBatch { get; set; }
        public virtual ICollection<FinishedProduct> FinishedProduct { get; set; }
        public virtual ICollection<StockBatch> StockBatch { get; set; }
    }
}