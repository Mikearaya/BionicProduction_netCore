/*
 * @CreateTime: Sep 30, 2018 5:42 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 30, 2018 5:42 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using BionicInventory.Domain.Items;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.FinishedProducts.Models {
    public class StockStatusView {

        private float _totalWriteOff = 0;
        private float _quantity = 0;
        private float _totalCost = 0;
        private float _inStock = 0;
        public uint itemId { get; set; }

        public string itemName { get; set; }

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
    }
}