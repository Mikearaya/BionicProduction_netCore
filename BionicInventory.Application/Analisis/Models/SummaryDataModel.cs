/*
 * @CreateTime: Nov 21, 2018 10:21 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 21, 2018 11:12 PM
 * @Description: Modify Here, Please 
 */
namespace BionicInventory.Application.Analisis.Models {
    public class SummaryDataModel {
        public int? activeManufactureOrders { get; set; }
        public int? totalMinStock { get; set; }
        public int? completedShipments { get; set; }
        public double? totalInventoryCost { get; set; }
        public int? overDueMO { get; set; }
        public int? overDuePayments { get; set; }
        public int? totalCustomers { get; set; }
        public int? totalProducts { get; set; }

        public int? totalMonthlySale { get; set; }

    }
}