using System.Collections.Generic;
using BionicInventory.Domain.Customers;

namespace BionicInventory.Application.Customers.Interfaces.Query
{
    public interface ICustomersQuery
    {
        Customer GetById(uint customerId);
        IEnumerable<Customer> GetAll();
    }
    
}