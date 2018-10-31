/*
 * @CreateTime: Sep 15, 2018 11:31 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 15, 2018 11:31 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Customers.Models;
using BionicInventory.Application.Interfaces;
using BionicInventory.Domain.Customers;

namespace BionicInventory.Application.Customers.Interfaces {
    public interface ICustomersCommand {
        CustomerViewModel Create (NewCustomerModel customer);
        bool Update (Customer oldCustomer,UpdatedCustomerModel customer);
        bool Delete (Customer customer);
    }
}