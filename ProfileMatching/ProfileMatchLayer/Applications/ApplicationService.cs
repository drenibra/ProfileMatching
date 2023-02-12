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
        private ISaveResults _results;
        private IGetJobPosition _getJobPosition;
        private readonly UserManager<AppUser> _userManager;
        public ApplicationService(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<bool> Apply(ApplicationDTO application)
        {
            _results = new ResultService(_context);
            _getJobPosition = new JobPositionService(_context);
            if (await ifExists(application.jobPositionId, application.applicantId))
            {
                return false;
            }
            CalculateMatch calculate = new CalculateMatch();
            try
            {
                Applicant applicant = await _userManager.FindByIdAsync(application.applicantId) as Applicant;
                JobPosition jobPosition = await _getJobPosition.GetJobPositionById(application.jobPositionId);

                Application a = new Application()
                {
                    date = DateTime.Now,
                    JobPositionId = application.jobPositionId,
                    ApplicantId = application.applicantId,
                    Applicant = applicant,
                    JobPosition = jobPosition
                };

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
            return await _context.applications.Where(x => x.ApplicantId == applicantId && x.JobPositionId == jobId).AnyAsync();

            //var applications = _context.applications.ToList();
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

        public async Task<string> DeleteApplication(int id)
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
        public async Task<List<Application>> GetApplications()
        {
            return await _context.applications.ToListAsync();
        }
        public async Task<List<Application>> GetApplicationsByJobId(int id)
        {
            return await _context.applications.Where(application => application.JobPosition.Id == id).Include(a => a.JobPosition).ThenInclude(JobPosition => JobPosition.Company).ToListAsync();
        }
        public async Task<List<Application>> GetApplicationsByApplicantId(string id)
        {
            return await _context.applications.Where(application => application.ApplicantId == id).Include(a => a.JobPosition).ThenInclude(JobPosition => JobPosition.Company).ToListAsync();
        }
    }
}