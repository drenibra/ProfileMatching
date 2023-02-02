using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileMatching.Models;
using ProfileMatching.Models.DTOs;

namespace ProfileMatching.RecruiterServices.JobPositions
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class JobPositionController : Controller
    {
        private readonly IJobPosition contract;
        public JobPositionController(IJobPosition contract)
        {
            this.contract = contract;
        }
        [HttpGet]
        public IActionResult GetJobPositions()
        {
            return Ok(contract.GetJobPositions());
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetJobPositionById(int id)
        {
            return Ok(await contract.GetJobPositionById(id));
        }
        [HttpPost]
        [Authorize(Roles = "Recruiter")]
        public async Task<IActionResult> AddJobPosition(JobPositionDTO jobPosition)
        {
            return Ok(await contract.AddJobPosition(jobPosition));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator, Recruiter")]
        public async Task<IActionResult> DeleteJobPosition(int id)
        {
            try
            {
                return Ok(await contract.DeleteJobPosition(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        [HttpPut]
        [Authorize(Roles = "Recruiter")]
        public void UpdateJobPosition(JobPositionDTO jobPosition)
        {
            contract.UpdateJobPosition(jobPosition);

        }
    }
}
