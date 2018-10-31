/*
 * @CreateTime: Oct 16, 2018 11:50 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 16, 2018 11:53 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.CompanyProfile.Interfaces;
using BionicInventory.Application.CompanyProfile.Models;
using BionicInventory.Domain.Companies;

namespace BionicInventory.Application.CompanyProfile.Factories {
    public class CompanyProfileFactories : ICompanyProfileFactories
    {
        public Company NewCompany(NewCompanyProfileDto newCompany)
        {
            return new Company() {
                Name = newCompany.Name,
                Tin = newCompany.Tin,
                Country = newCompany.Country,
                City = newCompany.City,
                SubCity = newCompany.SubCity,
                Location = newCompany.Location
            };
        }

        public Company NewCompany(UpdatedCompanyProfileDto updatedCompany)
        {
            return new Company() {
                Id = updatedCompany.Id,
                Name = updatedCompany.Name,
                Tin = updatedCompany.Tin,
                Country = updatedCompany.Country,
                City = updatedCompany.City,
                SubCity = updatedCompany.SubCity,
                Location = updatedCompany.Location
            };
        }
    }
}