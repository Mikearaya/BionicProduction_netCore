/*
 * @CreateTime: Feb 21, 2019 8:41 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 21, 2019 8:44 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.CRM.CustomerOrders.Models {
    public class NewCustomerOrderDto : IRequest<uint> {
        [Required]
        public string Status { get; set; }

        [Required]
        public uint ClientId { get; set; }

        [MaxLength (255)]
        public string Description { get; set; }
        public DateTime? DeliveryDate { get; set; }

        [Required]
        public IEnumerable<CustomerOrderItemDto> CustomerOrderDetail { get; set; } = new List<CustomerOrderItemDto> ();
    }
}