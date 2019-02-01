using System;
using System.Linq;
using System.Linq.Expressions;
using BionicInventory.Domain.Items;

namespace BionicInventory.Application.Stocks.Items.Models {
    public class ItemReportListView {

        private float _totalWriteOff = 0;
        private float _quantity = 0;
        private float _totalCost = 0;
        private float _inStock = 0;
        public uint id { get; set; }

        public string item { get; set; }

        public string itemCode { get; set; }

        public float inStock {
            get {
                return _inStock;
            }
            set {
                _inStock = value;
            }
        }
        public float available {
            get {
                return inStock - booked;
            }
        }

        public float booked { get; set; }

        public float totalExpected { get; set; }
        public float totalWriteOff {
            get {
                return _totalWriteOff;
            }
            set {
                _totalWriteOff = value;
            }
        }

        public float expectedAvailable {
            get {
                return totalExpected - expectedBooked;
            }
        }

        public float expectedBooked { get; set; }

        public float? minimumQuantity { get; set; }
        public string primaryUom { get; set; }
        public uint primaryUomId { get; set; }

        public float totalCost {
            get {
                return _totalCost;
            }
            set {
                _totalCost = value;
            }
        }
        public float averageCost {
            get {
                return (inStock != 0 || totalExpected != 0) ? _totalCost / (inStock + totalExpected) : 0;
            }
        }

        public static Expression<Func<IGrouping<Item, ItemLotJoin>, ItemReportListView>> Projection {
            get {
                return report => new ItemReportListView () {
                    id = report.Key.Id,
                    item = report.Key.Name,
                    itemCode = report.Key.Code,
                    minimumQuantity = report.Key.MinimumQuantity,
                    //     primaryUom = report.Key.PrimaryUom.Abrivation,
                    //     primaryUomId = report.Key.PrimaryUomId,
                    booked = report.Sum (b => b.Lot.Where (s => s.Batch.Status.ToUpper () == "RECIEVED").Sum (i => i.BookedStockBatch.Sum (a => a.Quantity))),
                    inStock = report.Sum (b => b.Lot.Where (s => s.Batch.Status.ToUpper () == "RECIEVED").Sum (i => i.Quantity)),
                    expectedBooked = report.Sum (b => b.Lot.Where (s => s.Batch.Status.ToUpper () == "PLANED").Sum (i => i.BookedStockBatch.Sum (a => a.Quantity))),
                    totalExpected = report.Sum (b => b.Lot.Where (s => s.Batch.Status.ToUpper () == "PLANED").Sum (i => i.Quantity)),
                    totalCost = report.Sum (b => b.Lot.Sum (i => i.Quantity * i.Batch.UnitCost)),
                };
            }
        }

    }
}