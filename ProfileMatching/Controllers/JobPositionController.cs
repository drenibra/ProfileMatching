using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileMatching.Models;
using ProfileMatching.Models.DTOs;
using ProfileMatching.RecruiterServices;
using ProfileMatching.RecruiterServices.Interfaces;

namespace ProfileMatching.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public async Task<IActionResult> GetJobPositionById(int id)
        {
            return Ok(await contract.GetJobPositionById(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddJobPosition(JobPositionDTO jobPosition)
        {
            return Ok(await contract.AddJobPosition(jobPosition));
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
