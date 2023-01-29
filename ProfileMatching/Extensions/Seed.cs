using Microsoft.AspNetCore.Identity;
using ProfileMatching.Configurations;
using ProfileMatching.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileMatching.Extensions
{
    public class Seed
    {
        public static async Task SeedData(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
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
                }
            }
            if (!context.jobPositions.Any()) 
            {
                var jobPosition = new JobPosition { Title = "Software Developer", Description = "Lorem ipsum", SkillSet = "React, .NET", CompanyId = 1, ExpiryDate = DateTime.Parse("01/30/2023") };    
                await context.jobPositions.AddRangeAsync(jobPosition);
                await context.SaveChangesAsync();
            }
        }
    }
}