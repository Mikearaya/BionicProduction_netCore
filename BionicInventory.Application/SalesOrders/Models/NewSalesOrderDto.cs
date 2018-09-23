/*
 * @CreateTime: Sep 23, 2018 7:28 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 23, 2018 7:28 PM
 * @Description: Modify Here, Please 
 */
namespace BionicInventory.Application.SalesOrders.Models {
    public class NewSalesOrderDto : SalesOrderDto {
        [Required]
        public IEnumerable<NewSalesOrderDetailDto> SalesDetail { get; set; }

    }
}