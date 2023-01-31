using Microsoft.AspNetCore.Mvc;
using ProfileMatching.Models;

namespace ProfileMatching.ProfileMatchLayer.Applicants
{
    public interface IGetUser
    {
        Task<ActionResult<AppUser>> GetUserById(string id);
    }
}
