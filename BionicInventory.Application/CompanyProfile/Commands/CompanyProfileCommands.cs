using System;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.CompanyProfile.Iterfaces;
using BionicInventory.Domain.Companies;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.CompanyProfile.Commands {
    public class CompanyProfileCommands : ICompanyProfileCommands
    {
        private readonly IInventoryDatabaseService _database;

        public ILogger<CompanyProfileCommands> _logger { get; }

        public CompanyProfileCommands(IInventoryDatabaseService database,
        ILogger<CompanyProfileCommands> logger) {
                _database = database;
                _logger = logger;
        }
        public Company CreateProfile(Company newProfile)
        {
            try {
                _database.Company.Add(newProfile);
                _database.Save();
                return newProfile;
            } catch(Exception e) {
                _logger.LogError(500, e.Message);
                return null;
            }
        }

        public bool UpdateProfile(Company updatedProfile)
        {
            try {
                _database.Company.Update(updatedProfile);
                _database.Save();
                return true;
            } catch(Exception e) {
                _logger.LogError(500, e.Message);
                return false;
            }
        }
    }
}