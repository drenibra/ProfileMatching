using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfileMatching.Models.DTOs;

namespace ProfileMatching.ProfileMatchLayer.Applications
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ApplicationController : Controller
    {
        private readonly ILogger<ApplicationController> _logger;
        private readonly IApplicationService _contract;
        public ApplicationController(ILogger<ApplicationController> logger, IApplicationService contract)
        {
            _logger = logger;
            _contract = contract;
        }

        [HttpGet]
        [Authorize(Roles = "Recruiter,Administrator")]
        public async Task<IActionResult> GetApplications()
        {
            return Ok(await _contract.GetApplications());
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Recruiter,Administrator")]
        public async Task<IActionResult> GetApplicationsByJobId(int id)
        {
            return Ok(await _contract.GetApplicationsByJobId(id));
        
        }
        [HttpGet("applicant/{id}")]
        [Authorize(Roles = "Applicant,Recruiter,Administrator")]
        public async Task<IActionResult> GetApplicationsByApplicantId(string id)
        {
            return Ok(await _contract.GetApplicationsByApplicantId(id));
        }
        [HttpPost]
        [Authorize(Roles = "Applicant")]
        public async Task<IActionResult> Apply(ApplicationDTO application)
        {
            return Ok(await _contract.Apply(application));
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Recruiter, Administrator")]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            try
            {
                return Ok(await _contract.DeleteApplication(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}