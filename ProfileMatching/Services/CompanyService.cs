using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileMatching.Configurations;
using ProfileMatching.Models;
using ProfileMatching.Services.Interfaces;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ProfileMatching.Services
{
    public class CompanyService : ICompany,ICompanyExistence
    {
        private readonly ApplicationDbContext _context;
        public CompanyService(ApplicationDbContext _context) {
            this._context = _context;
        }

        public async Task<List<Company>> GetCompanies()
        {
            return await _context.companies.ToListAsync();
        }

        public async Task<Company> GetCompany(int id)
        {
            return await _context.companies.FirstOrDefaultAsync(company => company.Id == id);
        }

        public async Task<Company> AddCompany(Company company)
        {
            _context.companies.Add(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<string> DeleteCompany(int id)
        {
            var result = await _context.companies.FirstOrDefaultAsync(c => c.Id == id);
                if (result != null)
                {
                    _context.companies.Remove(result);
                    await _context.SaveChangesAsync();
                    return "Compania me id="+id+" u fshie me sukses!";
                }
            return "Compania nuk u gjend!";
        }

        public JsonResult UpdateCompany(Company company)
        {
                _context.companies.Update(company);
                _context.SaveChanges();
                return new JsonResult("Compania u perditsua me sukses!");
        }

        public bool IsExistence(int id)
        {
            var result = _context.companies.FirstOrDefault(c => c.Id == id);
            if(result != null)
            {
                return true;
            }
            return false;
        }
    }
}
