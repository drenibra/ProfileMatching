using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProfileMatching.Models;
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
        [Authorize(Roles = "Recruiter, Administrator")]
        public async Task<IActionResult> GetApplications()
        {
            return Ok(await _contract.getApplications());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Recruiter, Administrator")]
        public async Task<IActionResult> getApplicationsByJobId(int id)
        {
            return Ok(await _contract.getApplicationsByJobId(id));
        }

        [HttpPost]
        [Authorize(Roles = "Applicant")]
        public async Task<IActionResult> Apply(ApplicationDTO application)
        {
            return Ok(await _contract.apply(application));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Recruiter, Administrator")]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            try
            {
                return Ok(await _contract.deleteApplication(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}