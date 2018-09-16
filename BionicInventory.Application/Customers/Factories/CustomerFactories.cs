/*
 * @CreateTime: Sep 15, 2018 11:34 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 15, 2018 11:34 PM
 * @Description: Customer Factory Class 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Application.Customers.Interfaces;
using BionicInventory.Application.Customers.Models;
using BionicInventory.Domain.Customers;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.Customers.Factories {
    public class CustomerFactories : ICustomersFactory {
        private readonly ILogger<CustomerFactories> _logger;

        public CustomerFactories (ILogger<CustomerFactories> logger) {
            _logger = logger;
        }
        public Customer CustomerForCreation (NewCustomerModel customer) {

            try {

                return new Customer () {
                    FirstName = customer.firstName,
                        LastName = customer.lastName,
                        Tin = customer.tin,
                        Email = customer.email,
                        Type = customer.type,
                        MainPhone = customer.mainPhone

                };

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);

                return null;
            }
        }

        public Customer CustomerForUpdate (Customer old, UpdatedCustomerModel customer) {

            try {

                old.FirstName = customer.firstName;
                old.LastName = customer.lastName;
                old.Tin = customer.Tin;
                old.Email = customer.email;
                old.Type = customer.type;
                old.MainPhone = customer.mainPhone;

                return old;

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);

                return null;
            }

        }

        public CustomerViewModel CustomerForView (Customer customer) {

            try {

                return new CustomerViewModel () {
                    id = customer.Id,
                        firstName = customer.FirstName,
                        lastName = customer.LastName,
                        tin = customer.Tin,
                        email = customer.Email,
                        type = customer.Type,
                        mainPhone = customer.MainPhone,
                        DateAdded = customer.DateAdded,
                        DateUpdated = customer.DateUpdated

                };

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);

                return null;
            }
        }

        public IEnumerable<CustomerViewModel> CustomerForView (IEnumerable<Customer> customer) {

            try {
                List<CustomerViewModel> customers = new List<CustomerViewModel> ();

                foreach (var item in customer) {

                    customers.Add (new CustomerViewModel () {
                        id = item.Id,
                            firstName = item.FirstName,
                            lastName = item.LastName,
                            tin = item.Tin,
                            email = item.Email,
                            type = item.Type,
                            mainPhone = item.MainPhone,
                            DateAdded = item.DateAdded,
                            DateUpdated = item.DateUpdated

                    });
                }
                return customers;

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);

                return null;
            }
        }
    }
}