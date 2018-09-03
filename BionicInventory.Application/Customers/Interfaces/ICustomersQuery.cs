using System.Collections.Generic;
using BionicInventory.Domain.Customers;

namespace BionicInventory.Application.Customers.Interfaces.Query
{
    public interface ICustomersQuery
    {
        Customer GetCustomerById(uint customerId);
        IList<Customer> GetAllCustomers();
    }
    
}