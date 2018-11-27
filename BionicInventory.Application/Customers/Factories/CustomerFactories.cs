/*
 * @CreateTime: Sep 15, 2018 11:34 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 27, 2018 9:09 PM
 * @Description: Customer Factory Class 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Application.Customers.Interfaces;
using BionicInventory.Application.Customers.Models;
using BionicInventory.Domain.Customers;
using BionicInventory.Domain.Customers.Addresses;
using BionicInventory.Domain.Customers.PhoneNumbers;
using BionicInventory.Domain.Customers.SocialMedias;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.Customers.Factories {
    public class CustomerFactories : ICustomersFactory {
        private readonly ILogger<CustomerFactories> _logger;

        public CustomerFactories (ILogger<CustomerFactories> logger) {
            _logger = logger;
        }
        public Customer CustomerForCreation (NewCustomerDto customer) {

            try {

                Customer newCustomer = new Customer () {
                    FullName = customer.FullName,
                    Tin = customer.tin,
                    Email = customer.email,
                    Type = customer.type,
                    CreditLimit = customer.creditLimit,
                    PaymentPeriod = customer.paymentPeriod
                };

                foreach (var item in customer.addresses) {
                    newCustomer.Address.Add (new Address () {
                        Country = item.Country,
                            City = item.City,
                            SubCity = item.SubCity,
                            Location = item.Location,
                            PhoneNumber = item.PhoneNumber
                    });
                }

                foreach (var item in customer.telephones) {
                    newCustomer.PhoneNumber.Add (new PhoneNumber () {
                        Number = item.number,
                            Type = item.type
                    });
                }

                foreach (var item in customer.socialMedias) {
                    newCustomer.SocialMedia.Add (new SocialMedia () {
                        Site = item.site,
                            Address = item.address
                    });
                }

                return newCustomer;

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);

                return null;
            }
        }

        public Customer CustomerForUpdate (Customer olds, UpdatedCustomerDto customer) {
            try {
                Customer old = new Customer () {
                    Id = customer.id,
                    FullName = customer.FullName,
                    Tin = customer.tin,
                    Email = customer.email,
                    Type = customer.type,
                    CreditLimit = customer.creditLimit,
                    PaymentPeriod = customer.paymentPeriod
                };

                foreach (var item in customer.telephones) {
                    PhoneNumber phone = new PhoneNumber () {
                        Id = (uint) item.id,
                        Number = item.number,
                        Type = item.type
                    };

                    old.PhoneNumber.Add (phone);
                }

                foreach (var item in customer.socialMedias) {
                    SocialMedia social = new SocialMedia () {
                        Id = (uint) item.Id,
                        Site = item.site,
                        Address = item.address
                    };

                    old.SocialMedia.Add (social);
                }

                foreach (var item in customer.addresses) {
                    Address address = new Address () {
                        Id = (uint) item.Id,
                        Country = item.Country,
                        City = item.City,
                        SubCity = item.SubCity,
                        Location = item.Location
                    };

                    old.Address.Add (address);
                }

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
                        fullName = customer.FullName,
                        tin = customer.Tin,
                        email = customer.Email,
                        type = customer.Type,
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
                            fullName = item.FullName,
                            tin = item.Tin,
                            email = item.Email,
                            type = item.Type,
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