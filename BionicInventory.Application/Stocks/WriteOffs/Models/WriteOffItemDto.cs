/*
 * @CreateTime: Jan 1, 2019 9:27 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 9:22 PM
 * @Description: Modify Here, Please 
 */
namespace BionicInventory.Application.Stocks.WriteOffs.Models {
    public class WriteOffItemDto {
        public uint BatchStorageId { get; set; }
        public uint WriteOffId { get; set; }
        public float Quantity { get; set; }
    }
}