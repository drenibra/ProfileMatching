using Microsoft.AspNetCore.Mvc;
using ProfileMatching.Models;
using ProfileMatching.Models.DTOs;

namespace ProfileMatching.RecruiterServices.Companies
{
    public interface ICompany
    {
        Task<List<Company>> GetCompanies();
        Task<Company> AddCompany(CompanyDTO company);
        Task<string> DeleteCompany(int id);
        JsonResult UpdateCompany(CompanyDTO company);
    }
}
