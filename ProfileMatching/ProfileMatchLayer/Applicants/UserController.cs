using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileMatching.Models;
using ProfileMatching.Models.DTOs;
using ProfileMatching.ProfileMatchLayer.Applicants;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IUserService _contract;

    public UserController(IUserService contract)
    {
        _contract = contract;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        return Ok(await _contract.GetUsers());
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(string id, AppUser user)
    {
        return Ok(await _contract.UpdateUser(id, user));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        return Ok(await _contract.DeleteUser(id));
    }
}