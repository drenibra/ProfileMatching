using Microsoft.AspNetCore.Mvc;
using ProfileMatching.Models.DTOs;

namespace ProfileMatching.Users.Interfaces
{
    public interface IGetCurrentUser
    {
        Task<ActionResult<UserDTO>> GetCurrentUser();
    }
}
