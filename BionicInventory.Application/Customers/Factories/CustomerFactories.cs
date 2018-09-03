using System.Collections.Generic;
using BionicInventory.Application.Customers.Interfaces;
using BionicInventory.Application.Customers.Models;
using BionicInventory.Domain.Customers;

namespace BionicInventory.Application.Customers.Factories {
    public class CustomerFactories : ICustomersFactory {
        public Customer CustomerForCreation (NewCustomerModel customer) {
            return new Customer () {
                FirstName = customer.firstName,
                    LastName = customer.lastName,
                    Tin = customer.Tin,
                    Email = customer.email,
                    Type = customer.type,
                    MainPhone = customer.mainPhone

            };
        }

        public Customer CustomerForUpdate (Customer old, UpdatedCustomerModel customer) {

            old.FirstName = customer.firstName;
            old.LastName = customer.lastName;
            old.Tin = customer.Tin;
            old.Email = customer.email;
            old.Type = customer.type;
            old.MainPhone = customer.mainPhone;

            return old;
        }

        public CustomerViewModel CustomerForView (Customer customer) {
            return new CustomerViewModel () {
                ID = customer.Id,
                    FullName = customer.FirstName + ' ' + customer.LastName,
                    Tin = customer.Tin,
                    email = customer.Email,
                    type = customer.Type,
                    mainPhone = customer.MainPhone,
                    DateAdded = customer.DateAdded,
                    DateUpdated = customer.DateUpdated

            };
        }

        public IEnumerable<CustomerViewModel> CustomerForView (IEnumerable<Customer> customer) {

            List<CustomerViewModel> customers = new List<CustomerViewModel> ();

            foreach (var item in customer) {

                customers.Add (new CustomerViewModel () {
                    ID = item.Id,
                        FullName = item.FirstName + ' ' + item.LastName,
                        Tin = item.Tin,
                        email = item.Email,
                        type = item.Type,
                        mainPhone = item.MainPhone,
                        DateAdded = item.DateAdded,
                        DateUpdated = item.DateUpdated

                });
            }
            return customers;
        }
    }
}