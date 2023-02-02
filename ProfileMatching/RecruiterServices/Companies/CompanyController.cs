using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileMatching.Models;
using ProfileMatching.Models.DTOs;

namespace ProfileMatching.RecruiterServices.Companies

{
    [Route("[controller]")]
    public class CompanyController : Controller
    {
        private ICompany contract;
        public CompanyController(ICompany contract)
        {
            this.contract = contract;
        }
        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            return Ok(await contract.GetCompanies());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany(int id)
        {
            return Ok(await contract.GetCompany(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddCompany(CompanyDTO company)
        {

            return Ok(await contract.AddCompany(company));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            try
            {
                return Ok(await contract.DeleteCompany(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        [HttpPut]
        public void UpdateCompany(CompanyDTO company)
        {
            contract.UpdateCompany(company);

        }
    }
}
