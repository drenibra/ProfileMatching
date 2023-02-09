using ProfileMatching.Configurations;
using ProfileMatching.Models;
using Microsoft.EntityFrameworkCore;
using ProfileMatching.ProfileMatchLayer.Results;
using ProfileMatching.ProfileMatchLayer.Results.Helpers;
using ProfileMatching.RecruiterServices.JobPositions;
using ProfileMatching.Models.DTOs;
using Microsoft.AspNetCore.Identity;

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
            if(await ifExists(application.jobPositionId, application.applicantId))
            {
                return false;
            }
            CalculateMatch calculate = new CalculateMatch();
            try
            {
                var applicant = await _userManager.FindByIdAsync(application.applicantId) as Applicant;

                Application a = new Application()
                {
                    date = DateTime.Now,
                    JobPositionId = application.jobPositionId,
                    ApplicantId = application.applicantId
                };

                JobPosition jobPosition = _getJobPosition.GetJobPositionById(application.jobPositionId);

                a.Applicant = applicant;
                a.JobPosition = jobPosition;

                _context.applications.Add(a);
                await _context.SaveChangesAsync();

                string jobRequirements = jobPosition.SkillSet;
                string applicantSkills = applicant.Skills;

                int result = calculate.CountSimilarities(jobRequirements, applicantSkills);

                double finalResult = calculate.GetPercentage(result, jobRequirements);


                ProfileMatchingResult profileMatchingResult = new()
                {
                    ApplicationId = a.Id,
                    Application = a,
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
        
        private async Task<bool> ifExists(int jobId, string applicantId)
        {
            //var applications = _context.applications.ToList();

// builder pattern
            return await _context.applications.Where(x => x.ApplicantId == applicantId && x.JobPositionId == jobId).AnyAsync();
//            if(applications.Count == 0)
//            {
//                return false;
//            }
///*me kqyr a ka aplikant edhe job position prezent ne nje rresht */
//            foreach(Application a in applications) { 
//                if(a.JobPositionId == jobId && a.ApplicantId.Equals(applicantId))
//                {
//                    return true;
//                }
//            }
//            return false;
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