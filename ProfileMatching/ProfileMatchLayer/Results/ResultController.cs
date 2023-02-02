using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProfileMatching.ProfileMatchLayer.Results
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(Roles = "Administrator, Recruiter")]
    public class ResultController:Controller
    {
        private readonly IResults _contract;
        public ResultController(IResults _contract) { 
            this._contract = _contract;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllResults()
        { 
            return Ok(await _contract.GetResults());
        }
    }
}
