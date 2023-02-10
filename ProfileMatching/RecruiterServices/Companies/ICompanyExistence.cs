using ProfileMatching.Models;

namespace ProfileMatching.RecruiterServices.Companies
{
    public interface ICompanyExistence
    {
        Task<bool> IsExistence(int id);
        Task<Company> GetCompanyById(int companyId);
    }
}
