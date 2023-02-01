using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileMatching.Models;
using ProfileMatching.Models.DTOs;
using ProfileMatching.ProfileMatchLayer.Users;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IUserService _contract;
    private readonly UserManager<AppUser> _userManager;

    public UserController(IUserService contract, UserManager<AppUser> userManager)
    {
        _contract = contract;
        _userManager = userManager;
    }

/*    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        return await _userManager.Users.ToListAsync().Result;
        *//*return Ok(await _contract.GetUsers());*//*
    }*/
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        return await _userManager.Users.ToListAsync();
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