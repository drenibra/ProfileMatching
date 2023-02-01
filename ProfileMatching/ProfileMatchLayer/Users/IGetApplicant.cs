using Microsoft.AspNetCore.Mvc;
using ProfileMatching.Models;

namespace ProfileMatching.ProfileMatchLayer.Users
{
    public interface IGetUser
    {
        Task<ActionResult<AppUser>> GetUserById(string id);
    }
}
