/*
 * @CreateTime: Dec 23, 2018 10:53 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 23, 2018 10:57 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using BionicInventory.Domain.Vendors;

namespace BionicInventory.Application.Vendors.Models {
    public class VendorsListView {

        public uint id { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string tinNumber { get; set; }
        public uint? leadTime { get; set; }
        public uint? paymentPeriod { get; set; }
        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }

        public static Expression<Func<Vendor, VendorsListView>> Projection {
            get {
                return vendor => new VendorsListView () {
                    id = vendor.Id,
                    name = vendor.Name,
                    phoneNumber = vendor.PhoneNumber,
                    tinNumber = vendor.TinNumber,
                    leadTime = vendor.LeadTime,
                    paymentPeriod = vendor.PaymentPeriod,
                    dateAdded = vendor.DateAdded,
                    dateUpdated = vendor.DateUpdated
                };
            }
        }
    }
}