/*
 * @CreateTime: Oct 21, 2018 1:00 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 8:57 PM
 * @Description: Modify Here, Please 
 */

using System;
using System.Linq;
using System.Linq.Expressions;
using BionicInventory.Application.Stocks.Items.Models;
using BionicInventory.Domain.Items;

namespace BionicInventory.Application.Products.Models {

    public class CriticalItemsView {
        public uint id { get; set; }
        public string itemName { get; set; }
        public string itemCode { get; set; }

        public float required {
            get {
                if (availableQuantity < minimumQuantity) {
                    return minimumQuantity - availableQuantity;
                } else {
                    return 0;
                }
            }
        }
        public float minimumQuantity { get; set; }

        public float availableQuantity { get; set; }
        public float expectedAvailableQuantity { get; set; }

        public string uom { get; set; }
        public string type { get; set; }

        public float inStock { get; set; }

        public static Expression<Func<IGrouping<Item, ItemLotJoin>, CriticalItemsView>> Projection {

            get {
                return critical => new CriticalItemsView () {
                    id = critical.Key.Id,
                    itemName = critical.Key.Name,
                    itemCode = critical.Key.Code,
                    minimumQuantity = (float) critical.Key.MinimumQuantity,
                    type = (critical.Key.IsProcured == 1) ? "Purchased" : "Manufactured",
                    inStock = critical
                    .Sum (l =>
                    l.Lot.Where (i =>
                    i.Batch.Status.ToUpper () == "RECIEVED"
                    ).Sum (q => q.Quantity)),
                    expectedAvailableQuantity = critical
                    .Sum (l =>
                    l.Lot.Where (i =>
                    i.Batch.Status.ToUpper () == "PLANED"
                    ).Sum (q => q.Quantity)),
                    //   uom = critical.Key.PrimaryUom.Abrivation,
                    availableQuantity = critical
                    .Sum (l =>
                    l.Lot.Where (i =>
                    i.Batch.Status.ToUpper () == "RECIEVED"
                    ).Sum (q => q.Quantity) - l.Lot.Sum (b => b.BookedStockBatch.Sum (q => q.Quantity))),

                };
            }
        }

    }
}