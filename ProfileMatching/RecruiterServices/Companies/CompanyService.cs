using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileMatching.Configurations;
using ProfileMatching.Helpers;
using ProfileMatching.Models;
using ProfileMatching.Models.DTOs;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ProfileMatching.RecruiterServices.Companies
{
    public class CompanyService : ICompany, ICompanyExistence
    {
         private readonly ApplicationDbContext _context;
         private readonly IWebHostEnvironment env;
         public CompanyService(ApplicationDbContext _context , IWebHostEnvironment env)
         {
             this._context = _context;
             this.env = env;
         }

         public async Task<List<Company>> GetCompanies()
         {
             return await _context.companies.ToListAsync();
         }

         public async Task<Company> GetCompany(int id)
         {
             return await _context.companies.FirstOrDefaultAsync(company => company.Id == id);
         }

         public Company GetCompanyById(int? id)
         {
             return  _context.companies.FirstOrDefault(company => company.Id == id);
         }

         public async Task<Company> AddCompany(CompanyDTO company)
         {
             string path = "Views/frontend/public/images";
             FileSaver fileSaver = new FileSaver(env);
             string fileName = $"{Guid.NewGuid()}{Path.GetExtension(company.image.FileName)}";

             Company c = new Company()
             {
                 Name = company.Name,
                 Location = company.Location,
                 Logo = fileName
             };
             _context.companies.Add(c);
             await _context.SaveChangesAsync();
             await fileSaver.FileSaveDocsAsync(company.image, path, fileName);
             return c;
         }

         public async Task<string> DeleteCompany(int id)
         {
             var result = await _context.companies.FirstOrDefaultAsync(c => c.Id == id);
             if (result != null)
             {
                 _context.companies.Remove(result);
                 await _context.SaveChangesAsync();
                 return "Compania me id=" + id + " u fshie me sukses!";
             }
             return "Compania nuk u gjend!";
         }

         public JsonResult UpdateCompany(CompanyDTO company)
         {
             Company c = new Company()
             {
                 Name = company.Name,
                 Location = company.Location
             };
             _context.companies.Update(c);
             _context.SaveChanges();
             return new JsonResult("Compania u perditsua me sukses!");
         }

         public bool IsExistence(int id)
         {
             var result = _context.companies.FirstOrDefault(c => c.Id == id);
             if (result != null)
             {
                 return true;
             }
             return false;
         }
    }
}
