using ProfileMatching.Models;

namespace ProfileMatching.RecruiterServices.Companies
{
    public interface ICompanyExistence
    {
        bool IsExistence(int id);
        Company GetCompanyById(int? companyId);
    }
}
