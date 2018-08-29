using BionicInventory.Application.Customers.Models;
using BionicInventory.Application.Interfaces;
using BionicInventory.Domain.Customers;

namespace BionicInventory.Application.Customers.Interfaces {
    public interface ICustomersCommand {
        CustomerViewModel Create (NewCustomerModel customer);
        bool Update (UpdatedCustomerModel customer);
        bool Delete (Customer customer);
    }
}