/*
 * @CreateTime: Feb 21, 2019 8:45 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 21, 2019 10:00 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.CRM.CustomerOrders.Models {
    public class UpdatedCustomerOrderDto : IRequest {
        public uint Id { get; set; }

        [Required]
        public string Status { get; set; }

        public string Description { get; set; }
        public DateTime? DeliveryDate { get; set; }

        [Required]
        public IEnumerable<CustomerOrderItemDto> CustomerOrderItems { get; set; } = new List<CustomerOrderItemDto> ();
    }
}