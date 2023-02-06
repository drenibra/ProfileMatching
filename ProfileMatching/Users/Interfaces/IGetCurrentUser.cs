using Microsoft.AspNetCore.Mvc;
using ProfileMatching.Models;

namespace ProfileMatching.Users.Interfaces
{
    public interface IGetCurrentUser
    {
        Task<ActionResult<AppUser>> GetCurrentUser();
    }
}
