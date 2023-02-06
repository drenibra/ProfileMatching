using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileMatching.Models;
using ProfileMatching.Models.DTOs;
using ProfileMatching.Services;
using System.Security.Claims;

namespace ProfileMatching.ProfileMatchLayer.Users
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController : Controller, IGetCurrentUser
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly TokenService _tokenService;
        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            TokenService tokenService
         )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (result.Succeeded)
            {
                return CreateUserObject(user);
            };

            return Unauthorized();
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDto)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
            {
                return BadRequest("Email taken!");
            }

            if (await _userManager.Users.AnyAsync(x => x.UserName == registerDto.Username))
            {
                return BadRequest("Username taken!");
            }

            var user = new Applicant
            {
                Email = registerDto.Email,
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                UserName = registerDto.Username,
                Skills = registerDto.Skills
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Applicant");
                return CreateUserObject(user);
            }

            return BadRequest("Problem registering user!");
        }

        [HttpPost("register/recruiter")]
        public async Task<ActionResult<UserDTO>> CreateRecruiter(RecruiterDTO recruiter)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == recruiter.Email))
            {
                return BadRequest("Email taken!");
            }

            if (await _userManager.Users.AnyAsync(x => x.UserName == recruiter.Username))
            {
                return BadRequest("Username taken!");
            }

            var user = new Recruiter
            {
                Email = recruiter.Email,
                Name = recruiter.Name,
                Surname = recruiter.Surname,
                UserName = recruiter.Username,
                CompanyId = recruiter.CompanyId,
                DateStarted= DateTime.Now
            };

            var result = await _userManager.CreateAsync(user, recruiter.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Recruiter");
                return CreateUserObject(user);
            }

            return BadRequest("Problem registering recruiter!");
        }


        [Authorize]
        [HttpGet]
        public async Task<ActionResult<AppUser>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            return user;
        }
        [Authorize]
        [HttpGet("roles")]
        public async Task<IList<string>> GetRoles()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
            var roles = _userManager.GetRolesAsync(user).Result;

            return roles;
        }
        private UserDTO CreateUserObject(AppUser user)
        {
            return new UserDTO
            {
                Name = user.Name,
                Surname = user.Surname,
                Token = _tokenService.CreateToken(user),
                Username = user.UserName
            };
        }
    }
}
