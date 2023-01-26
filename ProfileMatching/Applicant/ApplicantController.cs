using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProfileMatching.Applicant
{
    [Route("[controller]")]
    public class ApplicantController : Controller
    {
        private readonly ILogger<ApplicantController> _logger;

        private readonly IApplicantService _contract;

        public ApplicantController(ILogger<ApplicantController> logger, IApplicantService contract)
        {
            _logger = logger;
            _contract = contract;
        }

        [HttpGet]
        public async Task<IActionResult> GetApplicants()
        {
            return Ok(await _contract.GetApplicants());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicantById(int id)
        {
            return Ok(await _contract.getApplicantById(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicant(int id)
        {
            try
            {
                return Ok(await _contract.DeleteApplicant(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}