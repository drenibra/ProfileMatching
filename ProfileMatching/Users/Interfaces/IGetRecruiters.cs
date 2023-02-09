using Microsoft.AspNetCore.Mvc;
using ProfileMatching.Models;

namespace ProfileMatching.Users.Interfaces
{
    public interface IGetRecruiters
    {
        Task<ActionResult<IEnumerable<Recruiter>>> GetRecruiters();
    }
}
