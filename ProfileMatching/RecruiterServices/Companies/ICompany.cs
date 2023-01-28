using Microsoft.AspNetCore.Mvc;
using ProfileMatching.Models;

namespace ProfileMatching.RecruiterServices.Companies
{
    public interface ICompany
    {
        Task<List<Company>> GetCompanies();
        Task<Company> GetCompany(int id);
        Task<Company> AddCompany(Company company);
        Task<string> DeleteCompany(int id);
        JsonResult UpdateCompany(Company company);
    }
}
