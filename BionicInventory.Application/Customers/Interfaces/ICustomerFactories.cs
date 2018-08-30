using BionicInventory.Application.Customers.Models;
using BionicInventory.Domain.Customers;

namespace BionicInventory.Application.Customers.Interfaces
{
    public interface ICustomersFactory {
        Customer CustomerForCreation(NewCustomerModel customer);
        Customer CustomerForUpdate(Customer oldCustomer, UpdatedCustomerModel customer);
        CustomerViewModel CustomerForView(Customer customer);

    }
}