/*
 * @CreateTime: Sep 15, 2018 11:31 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 28, 2018 10:31 AM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Customers.Models;
using BionicInventory.Application.Interfaces;
using BionicInventory.Domain.Customers;
using BionicInventory.Domain.Customers.Addresses;
using BionicInventory.Domain.Customers.PhoneNumbers;
using BionicInventory.Domain.Customers.SocialMedias;

namespace BionicInventory.Application.Customers.Interfaces {
    public interface ICustomersCommand {
        CustomerViewModel Create (NewCustomerDto customer);
        bool UpdateCustomerData (Customer customer);
        bool Delete (Customer customer);

        bool DeleteCustomerAddress (Address deletedAddress);
        bool DeleteCustomerPhone (PhoneNumber deletedAddress);

        bool DeleteCustomerSocialAddress (SocialMedia deleteSocialAddress);
    }
}