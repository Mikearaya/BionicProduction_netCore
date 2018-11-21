using System.Collections.Generic;
using BionicInventory.Application.SalesOrders.Models.ReportModels;

namespace BionicInventory.Application.SalesOrders.Interfaces {
    public interface ISalesOrderReportQuery {
        IEnumerable<MonthlySalesReportModel> GetYearlySalesReport ();
        MonthlySalesReportModel GetSalesReportForAMonth (int monthNumber);
    }
}