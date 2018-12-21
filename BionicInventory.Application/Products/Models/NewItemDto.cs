/*
 * @CreateTime: Sep 9, 2018 8:25 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 2, 2018 10:48 PM
 * @Description: Modify Here, Please 
 */

using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.Products.Models {

    public class NewItemDto : IRequest<uint> {

        private float _minimumQuantity = 0;

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
        public uint DefaultStorageId { get; set; }

    }
}