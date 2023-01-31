using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileMatching.Configurations;
using ProfileMatching.Models;
using ProfileMatching.Models.DTOs;
using ProfileMatching.ProfileMatchLayer.Documents;
using System.Xml.Linq;

namespace ProfileMatching.ProfileMatchLayer.Applicants
{
    public class UserService : ControllerBase, IUserService, IGetUser
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _dbContext;

        public UserService(UserManager<AppUser> userManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _userManager.Users.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<AppUser>> UpdateUser(string id, AppUser user)
        {
            // This method is returning concurrency error
            /*            
             *      if (id != user.Id)
                        {
                            return BadRequest();
                        }
                        var result = await _userManager.UpdateAsync(user);
                        if (!result.Succeeded)
                        {
                            return BadRequest(result.Errors);
                        }
                    return NoContent();
            */

            var dbUser = await _dbContext.AppUsers.FindAsync(id);
            if (dbUser == null) return BadRequest("User not found!");

            dbUser.Name = user.Name;
            dbUser.Surname = user.Surname;
            dbUser.Skills = user.Skills;
            dbUser.Documents = user.Documents;
            dbUser.Company = user.Company;
            dbUser.DateStarted = user.DateStarted;
            dbUser.UserName = user.UserName;

            await _dbContext.SaveChangesAsync();

            return Ok(await _dbContext.AppUsers.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return NoContent();
        }
    }
}