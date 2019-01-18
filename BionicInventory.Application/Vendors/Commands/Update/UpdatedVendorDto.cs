/*
 * @CreateTime: Dec 23, 2018 10:58 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 23, 2018 10:59 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.Vendors.Commands.Update {
    public class UpdatedVendorDto : IRequest {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string TinNumber { get; set; }
        public uint? LeadTime { get; set; }
        public uint? PaymentPeriod { get; set; }

    }
}