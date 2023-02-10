using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfileMatching.Models.DTOs;

namespace ProfileMatching.RecruiterServices.JobPositions
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class JobPositionController : Controller
    {
        private readonly IJobPosition contract;
        private IWebHostEnvironment env;
        public JobPositionController(IJobPosition contract, IWebHostEnvironment env)
        {
            this.contract = contract;
            this.env = env;
        }
        /*[HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetJobPositionById(int id)*/

        [HttpGet]
        public async Task<IActionResult> GetJobPositions()
        {
            return Ok(await contract.GetJobPositions());
        }

        [HttpPost]
        [Authorize(Roles = "Recruiter")]
        public async Task<IActionResult> AddJobPosition(JobPositionDTO jobPosition)
        {
            return Ok(await contract.AddJobPosition(this.env, jobPosition));
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
