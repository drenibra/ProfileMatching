using Microsoft.AspNetCore.Mvc;
using ProfileMatching.Models;
using ProfileMatching.Models.DTOs;

namespace ProfileMatching.ProfileMatchLayer.Users
{
    public interface IUserService
    {
        Task<ActionResult<IEnumerable<AppUser>>> GetUsers();
        Task<ActionResult<IEnumerable<Recruiter>>> GetRecruiters();
        Task<ActionResult<AppUser>> GetUserById(string id);
        Task<ActionResult<AppUser>> UpdateUser(string id, AppUser user);
        Task<IActionResult> DeleteUser(string id);
        Task<List<Applicant>> GetApplicants();
        Applicant getApplicantById(string id);
    }
}