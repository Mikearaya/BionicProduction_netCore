/*
 * @CreateTime: Sep 15, 2018 11:30 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 27, 2018 9:11 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Customers.Interfaces.Query;
using BionicInventory.Application.Customers.Models;
using BionicInventory.Application.Customers.Models.Addresses;
using BionicInventory.Application.Customers.Models.PhoneNumbers;
using BionicInventory.Application.Customers.Models.SocialMedias;
using BionicInventory.Domain.Customers;
using BionicInventory.Domain.Customers.Addresses;
using BionicInventory.Domain.Customers.PhoneNumbers;
using BionicInventory.Domain.Customers.SocialMedias;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.Customers.Queries {
    public class CustomersQuery : ICustomersQuery {
        private readonly IInventoryDatabaseService _database;
        private readonly ILogger<CustomersQuery> _logger;

        public CustomersQuery (IInventoryDatabaseService database,
            ILogger<CustomersQuery> logger) {
            _database = database;
            _logger = logger;
        }
        public IList<Customer> GetAllCustomers () {

            try {

                return _database.Customer.ToList ();

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);
                return null;
            }
        }

        public Address GetCustomerAddress (uint customerId, uint id) {
            return _database.Address
                .Where (s => s.ClientId == customerId && s.Id == id)
                .FirstOrDefault ();
        }

        public Customer GetCustomerById (uint customerId) {

            try {

                return _database.Customer.AsNoTracking ().Where (c => c.Id == customerId)
                    .Include (c => c.SocialMedia)
                    .Include (c => c.Address)
                    .Include (c => c.PhoneNumber)
                    .FirstOrDefault ();

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);
                return null;
            }
        }

        public PhoneNumber GetCustomerPhone (uint customerId, uint id) {
            return _database.PhoneNumber
                .Where (s => s.ClientId == customerId && s.Id == id)
                .FirstOrDefault ();
        }

        public SocialMedia GetCustomerSocialAddress (uint customerId, uint id) {
            return _database.SocialMedia
                .Where (s => s.ClientId == customerId && s.Id == id)
                .FirstOrDefault ();
        }

        public CustomerViewModel GetCustomerViewById (uint id) {
            return _database.Customer.Select (cus => new CustomerViewModel () {
                id = cus.Id,
                    fullName = cus.FullName,
                    email = cus.Email,
                    type = cus.Type,
                    tin = cus.Tin,
                    paymentPeriod = cus.PaymentPeriod,
                    creditLimit = cus.CreditLimit,
                    DateAdded = cus.DateAdded,
                    DateUpdated = cus.DateUpdated,
                    telephones = cus.PhoneNumber.Select (p => new CustomerPhoneView () {
                        id = p.Id,
                            type = p.Type,
                            number = p.Number
                    }).ToList (),
                    addresses = cus.Address.Select (a => new CustomerAddressView () {
                        id = a.Id,
                            location = a.Location,
                            subCity = a.SubCity,
                            phoneNumber = a.PhoneNumber,
                            country = a.Country,
                            city = a.City,
                    }).ToList (),
                    socialMedias = cus.SocialMedia.Select (s => new CustomerSocialMediaView () {
                        id = s.Id,
                            site = s.Site,
                            address = s.Address
                    }).ToList ()

            }).FirstOrDefault (c => c.id == id);
        }

        public bool IsPhoneUnique (string phoneNumber) {
            var phone = _database.PhoneNumber
                .Where (p => p.Number == phoneNumber)
                .FirstOrDefault ();

            return (phone == null) ? true : false;
        }

        public bool IsTinUnique (string tinNo) {
            var tin = _database.Customer
                .Where (c => c.Tin == tinNo)
                .FirstOrDefault ();

            return (tin == null) ? true : false;
        }

        List<CustomerViewModel> ICustomersQuery.GetCustomerView () {

            return _database.Customer.Select (cus => new CustomerViewModel () {
                id = cus.Id,
                    fullName = cus.FullName,
                    email = cus.Email,
                    type = cus.Type,
                    tin = cus.Tin,
                    DateAdded = cus.DateAdded,
                    DateUpdated = cus.DateUpdated,
                    telephones = cus.PhoneNumber.Select (p => new CustomerPhoneView () {
                        id = p.Id,
                            type = p.Type,
                            number = p.Number
                    }).ToList (),
                    addresses = cus.Address.Select (a => new CustomerAddressView () {
                        id = a.Id,
                            location = a.Location,
                            subCity = a.SubCity,
                            phoneNumber = a.PhoneNumber,
                            country = a.Country,
                            city = a.City,
                    }).ToList (),
                    socialMedias = cus.SocialMedia.Select (s => new CustomerSocialMediaView () {
                        id = s.Id,
                            site = s.Site,
                            address = s.Address
                    }).ToList ()

            }).ToList ();
        }

    }
}