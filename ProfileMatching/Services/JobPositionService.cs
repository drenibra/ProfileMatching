using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileMatching.Configurations;
using ProfileMatching.Models;
using ProfileMatching.Models.DTOs;
using ProfileMatching.Services.Interfaces;

namespace ProfileMatching.Services
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

        public async Task<List<JobPosition>> GetJobPositions()
        {
            return await _context.jobPositions.ToListAsync();
        }

        public async Task<JobPosition> GetJobPositionById(int id)
        {
            return await _context.jobPositions.FirstOrDefaultAsync(JobPosition => JobPosition.Id == id);
        }

        public JsonResult UpdateJobPosition(JobPosition jobPosition)
        {
            _context.jobPositions.Update(jobPosition);
            _context.SaveChanges();
            return new JsonResult("Pozita e punes u perditsua me sukses!");
        }

        public JsonResult UpdateJobPosition(JobPositionDTO jobPosition)
        {
            throw new NotImplementedException();
        }
    }
}
