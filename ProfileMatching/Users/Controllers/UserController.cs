using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileMatching.Models;
using ProfileMatching.Users.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
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
    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        return await _userManager.Users.ToListAsync();
    }

    [HttpGet("applicant")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<List<Applicant>>> GetApplicants()
    {
        return await _contract.GetApplicants();
    }

    [HttpGet("applicant/{id}")]
    public ActionResult<AppUser> GetApplicantById(string id)
    {
        return Ok(_contract.getApplicantById(id));
    }


    [HttpGet("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<AppUser>> GetUserById(string id)
    {
        return Ok(await _contract.GetUserById(id));
    }
    [HttpPut("{id}")]
    [Authorize(Roles = "Administrator,Applicant")]
    public async Task<IActionResult> UpdateUser(string id, AppUser user)
    {
        return Ok(await _contract.UpdateUser(id, user));
    }
    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        return Ok(await _contract.DeleteUser(id));
    }
}