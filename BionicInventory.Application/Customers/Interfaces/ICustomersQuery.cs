/*
 * @CreateTime: Sep 15, 2018 11:31 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 27, 2018 5:13 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Customers.Models;
using BionicInventory.Domain.Customers;
using BionicInventory.Domain.Customers.Addresses;
using BionicInventory.Domain.Customers.PhoneNumbers;
using BionicInventory.Domain.Customers.SocialMedias;

namespace BionicInventory.Application.Customers.Interfaces.Query {
    public interface ICustomersQuery {
        Customer GetCustomerById (uint customerId);
        IList<Customer> GetAllCustomers ();

        List<CustomerViewModel> GetCustomerView ();

        CustomerViewModel GetCustomerViewById (uint id);

        Address GetCustomerAddress (uint customerId, uint id);

        PhoneNumber GetCustomerPhone (uint customerId, uint id);

        SocialMedia GetCustomerSocialAddress (uint customerId, uint id);

        bool IsPhoneUnique (string phoneNumber);

        bool IsTinUnique (string tinNo);
    }

}