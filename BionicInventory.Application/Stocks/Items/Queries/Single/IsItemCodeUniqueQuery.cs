/*
 * @CreateTime: Feb 7, 2019 2:49 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 7, 2019 2:50 AM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.Stocks.Items.Queries.Single {
    public class IsItemCodeUniqueQuery : IRequest<bool> {
        [Required]
        public string itemCode { get; set; }
    }
}