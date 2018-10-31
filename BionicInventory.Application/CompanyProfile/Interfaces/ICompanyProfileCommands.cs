


using BionicInventory.Domain.Companies;

namespace BionicInventory.Application.CompanyProfile.Iterfaces {
    public interface ICompanyProfileCommands {

        Company CreateProfile(Company newProfile);
        bool UpdateProfile(Company updatedProfile);

    }
}
