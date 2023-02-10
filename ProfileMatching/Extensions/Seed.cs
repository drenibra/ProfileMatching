using Microsoft.AspNetCore.Identity;
using ProfileMatching.Configurations;
using ProfileMatching.Models;
using ProfileMatching.Users.Interfaces;

namespace ProfileMatching.Extensions
{
    public class Seed
    {
        public static async Task SeedData(ApplicationDbContext context,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IGetRecruiters getRecruiters)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                await roleManager.CreateAsync(new IdentityRole("Administrator"));
            }

            if (!roleManager.RoleExistsAsync("Applicant").Result)
            {
                await roleManager.CreateAsync(new IdentityRole("Applicant"));
            }

            if (!roleManager.RoleExistsAsync("Recruiter").Result)
            {
                await roleManager.CreateAsync(new IdentityRole("Recruiter"));
            }
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser{Name = "Dren", UserName="dreni", Surname = "Ibrahimi", Email = "di53843@ubt-uni.net"},
                    new AppUser{Name = "Fitore", UserName="fitore", Surname = "Tahiri", Email = "ft53961@ubt-uni.net"},
                    new AppUser{Name = "Arber", UserName="arber", Surname = "Zeka", Email = "az51866@ubt-uni.net"},
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                    await userManager.AddToRoleAsync(user, "Administrator");
                }
            }
            if (!context.companies.Any())
            {
                var company = new Company { Name = "Test", Location = "Prishtine", Logo = "123.png" };
                await context.companies.AddRangeAsync(company);
                await context.SaveChangesAsync();
            }
            if (!getRecruiters.GetRecruiters().Result.Value.Any())
            {
                var recruiter = new Recruiter { Name = "Filan", Surname = "Fisteku", UserName = "filani12", Email = "filani@hotmail.com", CompanyId = 1, DateStarted = DateTime.Now };
                await userManager.CreateAsync(recruiter, "Pa$$w0rd");
                await userManager.AddToRoleAsync(recruiter, "Recruiter");
            }
            if (!context.jobPositions.Any())
            {
                var recruiter = await userManager.FindByEmailAsync("filani@hotmail.com") as Recruiter;
                var jobPosition = new JobPosition { Title = "Software Developer", Description = "Lorem ipsum", SkillSet = "React, .NET", CompanyId = 1, RecruiterId = recruiter.Id, Recruiter = recruiter, ExpiryDate = DateTime.Parse("03/07/2023"), Category = "Software Developer" };
                await context.jobPositions.AddRangeAsync(jobPosition);
                await context.SaveChangesAsync();
            }
        }
    }
}