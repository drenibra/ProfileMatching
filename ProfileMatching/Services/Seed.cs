using Microsoft.AspNetCore.Identity;
using ProfileMatching.Configurations;
using ProfileMatching.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileMatching.Services
{
    public class Seed
    {
        public static async Task SeedData(ApplicationDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
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
            if (!context.jobPositions.Any())
            {
                var jobPosition = new JobPosition { Title = "Software Developer", Description = "Lorem ipsum", SkillSet = "React, .NET", CompanyId = 1, ExpiryDate = DateTime.Parse("02/07/2023"), Category = "Software Developer" };
                await context.jobPositions.AddRangeAsync(jobPosition);
                await context.SaveChangesAsync();
            }
        }
    }
}