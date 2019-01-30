/*
 * @CreateTime: Sep 9, 2018 8:25 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 9, 2018 8:25 PM
 * @Description: Modify Here, Please 
 */
/*
 * @CreateTime: Sep 9, 2018 6:14 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 7:29 PM
 * @Description: Modify Here, Please 
 */

using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.Stocks.Items.Models {
    public class UpdatedItemDto : IRequest {
        private float _minimumQuantity = 0;
        [Required]
        public uint id { get; set; }

        [Required]
        public string code { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public float MinimumQuantity {
            get { return _minimumQuantity; }
            set { _minimumQuantity = (value >= 0) ? value : 0; }
        }
        public float weight { get; set; }

        [Required]
        public float unitCost { get; set; }

        public string image { get; set; }
        public sbyte isInventoryItem { get; set; }
        public sbyte isProcured { get; set; }
        public uint primaryUomId { get; set; }
        public float? price { get; set; }
        public uint? shelfLife { get; set; }
        public uint groupId { get; set; }

    }
}