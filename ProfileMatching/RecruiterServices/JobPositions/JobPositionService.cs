using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileMatching.Configurations;
using ProfileMatching.Models;
using ProfileMatching.Models.DTOs;
using ProfileMatching.RecruiterServices.Companies;
using System.Diagnostics.Contracts;

namespace ProfileMatching.RecruiterServices.JobPositions
{ 
    public class JobPositionService : IJobPosition,IGetJobPosition
    {
        private readonly ApplicationDbContext _context;
        private ICompanyExistence company;
        private IWebHostEnvironment? _env = null;
        public JobPositionService(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public async Task<string> AddJobPosition(IWebHostEnvironment env, JobPositionDTO jobPosition)
        {
            _env = env;
            company = new CompanyService(this._context, this._env);
            if (company.IsExistence(jobPosition.companyId))
            {
                DateTime today = DateTime.Now;

                JobPosition job = new JobPosition
                {
                    CompanyId = jobPosition.companyId,
                    Title = jobPosition.Title,
                    Description = jobPosition.Description,
                    SkillSet = jobPosition.SkillSet,
                    ExpiryDate = jobPosition.ExpiryDate,
                    CreatedAt = today
                    //Company =await company.GetCompanyById(jobPosition.companyId)
                };
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

        public async Task<List<JobPosition>> GetJobPositions(IWebHostEnvironment env)
        {
            _env = env;
            company = new CompanyService(this._context, this._env);
            List<JobPosition> result = new List<JobPosition>();
            var jobs = await _context.jobPositions.ToListAsync();
            try
            {
                foreach (JobPosition job in jobs)
                {
                    if (job.ExpiryDate.CompareTo(DateTime.Now) == -1)
                    {
                        continue;
                    }
                    else
                    {
                        job.Company = company.GetCompanyById(job.CompanyId);
                        result.Add(job);
                    }
                }
            }catch(Exception ex)
            {
                string message = ex.Message;
            }
            return result;
        }

        public JobPosition GetJobPositionById(int id)
        {
            return _context.jobPositions.FirstOrDefault(JobPosition => JobPosition.Id == id);
        }

        public JsonResult UpdateJobPosition(JobPositionDTO jobPosition)
        {
            JobPosition job = new JobPosition();
            job.CompanyId = jobPosition.companyId;
            job.SkillSet = jobPosition.SkillSet;
            job.Title = jobPosition.Title;
            job.Description = jobPosition.Description;
            job.ExpiryDate = jobPosition.ExpiryDate;

            _context.jobPositions.Update(job);
            _context.SaveChanges();
            return new JsonResult("Pozita e punes u perditsua me sukses!");
        }
    }
}
