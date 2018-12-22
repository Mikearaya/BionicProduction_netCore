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

        public uint itemId { get; set; }

        public string itemName { get; set; }

        public string itemCode { get; set; }

        public int inStock { get; set; }
        public int available { get; set; }

        public int booked { get; set; }

        public int totalExpected { get; set; }

        public int expectedAvailable { get; set; }

        public int expectedBooked { get; set; }

        public float? minimumQuantity { get; set; }
        public string primaryUom { get; set; }
        public uint primaryUomId { get; set; }

        public double totalCost { get; set; }
        public float averageCost { get; set; }
    }
}