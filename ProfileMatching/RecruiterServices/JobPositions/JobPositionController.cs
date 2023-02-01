using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileMatching.Models;
using ProfileMatching.Models.DTOs;

namespace ProfileMatching.RecruiterServices.JobPositions
{ 
    [ApiController]
    [Route("api/[controller]")]
    public class JobPositionController : Controller
    {
        private readonly IJobPosition contract;
        private IWebHostEnvironment env;
        public JobPositionController(IJobPosition contract, IWebHostEnvironment env)
        {
            this.contract = contract;
            this.env = env;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobPositions()
        {
            return Ok(await contract.GetJobPositions(this.env));
        }

        [HttpPost]
        public async Task<IActionResult> AddJobPosition(JobPositionDTO jobPosition)
        {
            return Ok(await contract.AddJobPosition(this.env, jobPosition));
        }

        [HttpDelete("{id}")]
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
        public void UpdateJobPosition(JobPositionDTO jobPosition)
        {
            contract.UpdateJobPosition(jobPosition);

        }
    }
}
