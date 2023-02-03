using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProfileMatching.Configurations;
using ProfileMatching.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using ProfileMatching.ProfileMatchLayer.Results;
using ProfileMatching.ProfileMatchLayer.Results.Helpers;
using ProfileMatching.ProfileMatchLayer.Users;
using ProfileMatching.RecruiterServices.JobPositions;
using ProfileMatching.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ProfileMatching.ProfileMatchLayer.Applications
{
    public class ApplicationService : IApplicationService
    {
        private readonly ApplicationDbContext _context;
        private readonly ISaveResults _results;
        private readonly IGetJobPosition _getJobPosition;
        private readonly UserManager<AppUser> _userManager;
        public ApplicationService(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _results = new ResultService(context);
            _getJobPosition = new JobPositionService(context);
            _userManager = userManager;
        }
        public async Task<bool> apply(ApplicationDTO application)
        {
            CalculateMatch calculate = new CalculateMatch();
            try
            {
                //This returns null
                //AppUser applicant = _getCurrentUser.GetCurrentUser().Result.Value;

                AppUser applicant = await _userManager.FindByIdAsync(application.applicantId);

                Application a = new Application()
                {
                    ApplicantId = application.applicantId,
                    date = DateTime.Now,
                    JobPositionId = application.jobPositionId
                };

                JobPosition jobPosition = _getJobPosition.GetJobPositionById(application.jobPositionId);

                /*a.Applicant = applicant;
                a.JobPosition = jobPosition;*/

                _context.applications.Add(a);
                await _context.SaveChangesAsync();

                string jobRequirements = jobPosition.SkillSet;
                string applicantSkills = applicant.Skills;

                int result = calculate.CountSimilarities(jobRequirements, applicantSkills);

                double finalResult = calculate.GetPercentage(result, jobRequirements);


                ProfileMatchingResult profileMatchingResult = new ProfileMatchingResult()
                {
                    ApplicationId = a.Id,
                    application = a,
                    Result = finalResult
                };

                await _results.AddResult(profileMatchingResult);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<string> deleteApplication(int id)
        {
            var result = await _context.applications.FirstOrDefaultAsync(c => c.Id == id);
            if (result != null)
            {
                _context.applications.Remove(result);
                await _context.SaveChangesAsync();
                return "Aplikimi me id=" + id + " u fshi me sukses!";
            }
            return "Nuk ka rezultate per kete aplikim!";
        }
        public async Task<List<Application>> getApplications()
        {
            return await _context.applications.ToListAsync();
        }
        public async Task<Application> getApplicationsByJobId(int id)
        {
            return await _context.applications.FirstOrDefaultAsync(application => application.JobPosition.Id == id);
        }
    }
}