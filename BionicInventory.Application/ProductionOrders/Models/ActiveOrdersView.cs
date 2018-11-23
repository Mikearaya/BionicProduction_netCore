/*
 * @CreateTime: Oct 18, 2018 9:58 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 23, 2018 10:22 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.ProductionOrders.Models {
    public class ActiveOrdersView {
        //  private string _manufacturerderItemId;
        //private string _manufacturerderId;
        public uint id { get; set; }
        public uint? total { get; set; }
        public int? remaining { get; set; }
        public double? percentageCompleted { get; set; }
        public DateTime dueDate { get; set; }
        public DateTime Start { get; set; }
    }
}