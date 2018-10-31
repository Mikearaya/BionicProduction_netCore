using System.Linq;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.CompanyProfile.Interfaces;
using BionicInventory.Application.CompanyProfile.Models;
using BionicInventory.Domain.Companies;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.CompanyProfile.Queries {
    public class CompanyProfileQueries : ICompanyProfileQueries
    {
        private readonly ILogger<CompanyProfileQueries> _logger;
        private readonly IInventoryDatabaseService _database;

        public CompanyProfileQueries(IInventoryDatabaseService database,
                ILogger<CompanyProfileQueries> logger) {
                    _logger = logger;
                    _database = database;
                }
        public Company GetCompany(uint id)
        {
            return _database.Company.Select(company => new Company() {
                Id = company.Id,
                Name = company.Name,
                Tin = company.Tin,
                Country = company.Country,
                City = company.City,
                SubCity = company.SubCity,
                Location = company.Location,
                DateAdded = company.DateAdded,
                DateUpdated = company.DateUpdated
            }).FirstOrDefault(company => company.Id == id );
        }

        public CompanyProfileView GetCompanyProfileView()
        {
            return _database.Company.Select(company => new CompanyProfileView() {
                id = company.Id,
                name = company.Name,
                tin = company.Tin,
                country = company.Country,
                city = company.City,
                subCity = company.SubCity,
                location = company.Location,
                dateAdded = company.DateAdded,
                dateUpdated = company.DateUpdated
            }).FirstOrDefault();
        }
    }
}