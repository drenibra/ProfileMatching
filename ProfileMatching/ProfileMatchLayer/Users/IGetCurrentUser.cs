using Microsoft.AspNetCore.Mvc;
using ProfileMatching.Models;
using ProfileMatching.Models.DTOs;

namespace ProfileMatching.ProfileMatchLayer.Users
{
    public interface IGetCurrentUser
    {
        Task<ActionResult<AppUser>> GetCurrentUser();
    }
}
