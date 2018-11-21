/*
 * @CreateTime: Nov 21, 2018 10:21 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 21, 2018 10:57 AM
 * @Description: Modify Here, Please 
 */
namespace BionicInventory.Application.Analisis.Models {
    public class SummaryDataModel {
        public string activeManufactureOrders { get; set; }
        public int? customerOrders { get; set; }
        public int? totalMinStock { get; set; }
        public int? completedShipments { get; set; }
        public int? totalInventoryCost { get; set; }
        public double? totalProfit { get; set; }

    }
}