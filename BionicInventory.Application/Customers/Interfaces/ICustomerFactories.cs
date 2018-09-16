/*
 * @CreateTime: Sep 15, 2018 11:31 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 15, 2018 11:31 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Customers.Models;
using BionicInventory.Domain.Customers;

namespace BionicInventory.Application.Customers.Interfaces
{
    public interface ICustomersFactory {
        Customer CustomerForCreation(NewCustomerModel customer);
        Customer CustomerForUpdate(Customer oldCustomer, UpdatedCustomerModel customer);
        CustomerViewModel CustomerForView(Customer customer);

        IEnumerable<CustomerViewModel> CustomerForView(IEnumerable<Customer> customer);

    }
}