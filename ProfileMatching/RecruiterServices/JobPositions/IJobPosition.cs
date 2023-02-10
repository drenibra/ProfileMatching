using Microsoft.AspNetCore.Mvc;
using ProfileMatching.Models;
using ProfileMatching.Models.DTOs;

namespace ProfileMatching.RecruiterServices.JobPositions
{
    public interface IJobPosition
    {
        Task<List<JobPosition>> GetJobPositions();
      //  Task<JobPosition> GetJobPositionById(int id);
        Task<string> AddJobPosition(IWebHostEnvironment env,JobPositionDTO jobPosition);
        Task<string> DeleteJobPosition(int id);
        JsonResult UpdateJobPosition(JobPositionDTO jobPosition);
    }
}
