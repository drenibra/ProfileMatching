using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileMatching.Configurations;
using ProfileMatching.Models;
using ProfileMatching.Models.DTOs;
using ProfileMatching.RecruiterServices.Interfaces;

namespace ProfileMatching.RecruiterServices
{
    public class JobPositionService:IJobPosition
    {
        private readonly ApplicationDbContext _context;
        private ICompanyExistence company;
        public JobPositionService(ApplicationDbContext _context)
        {
            this._context = _context;
            company = new CompanyService(this._context);
        }

        public async Task<string> AddJobPosition(JobPositionDTO jobPosition)
        {
            if (company.IsExistence(jobPosition.companyId))
            {
                JobPosition job = new JobPosition();
                job.CompanyId = jobPosition.companyId;
                job.Title = jobPosition.Title;
                job.Description = jobPosition.Description;
                job.SkillSet = jobPosition.SkillSet;
                job.ExpiryDate = jobPosition.ExpiryDate;
                _context.jobPositions.Add(job);
                await _context.SaveChangesAsync();
                return "Pozita e punes u shtua!";
            }
            return "Pozita e punes nuk u shtua meqe kompania qe shenuat nuk ekziston!";
        }

        public async Task<string> DeleteJobPosition(int id)
        {
            var result = await _context.jobPositions.FirstOrDefaultAsync(j => j.Id == id);
            if (result != null)
            {
                _context.jobPositions.Remove(result);
                await _context.SaveChangesAsync();
                return "Pozita e punes me id=" + id + " u fshie me sukses!";
            }
            return "Pozita e punes nuk u gjend!";
        }
        
        public List<JobPosition> GetJobPositions()
        {
            List<JobPosition> result = new List<JobPosition>();
            foreach(JobPosition job in _context.jobPositions)
            {
                if (job.ExpiryDate.CompareTo(DateTime.Now) == -1)
                {
                    continue;
                }
                else result.Add(job);
            }
            return result;
        }

        public async Task<JobPosition> GetJobPositionById(int id)
        {
            return await _context.jobPositions.FirstOrDefaultAsync(JobPosition => JobPosition.Id == id);
        }

        public JsonResult UpdateJobPosition(JobPositionDTO jobPosition)
        {
            JobPosition job = new JobPosition();
            job.CompanyId = jobPosition.companyId;
            job.SkillSet = jobPosition.SkillSet;
            job.Title=jobPosition.Title;
            job.Description=jobPosition.Description;
            job.ExpiryDate = jobPosition.ExpiryDate;

            _context.jobPositions.Update(job);
            _context.SaveChanges();
            return new JsonResult("Pozita e punes u perditsua me sukses!");
        }

        //Duhet me bo ni metod qe e kqyr a u bo expire ni jobposition, nese u bo expire e arkivon
    }
}
