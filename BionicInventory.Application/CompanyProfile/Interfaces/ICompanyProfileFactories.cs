/*
 * @CreateTime: Oct 16, 2018 11:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 16, 2018 11:35 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.CompanyProfile.Models;
using BionicInventory.Domain.Companies;

namespace BionicInventory.Application.CompanyProfile.Interfaces
{
    
    public  interface ICompanyProfileFactories {

        Company NewCompany(NewCompanyProfileDto newCompany);
        Company NewCompany(UpdatedCompanyProfileDto updatedCompany);

    }
}
