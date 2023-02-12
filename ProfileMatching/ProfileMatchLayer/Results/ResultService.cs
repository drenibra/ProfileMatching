using Microsoft.EntityFrameworkCore;
using ProfileMatching.Configurations;
using ProfileMatching.Models;

namespace ProfileMatching.ProfileMatchLayer.Results
{
    public class ResultService : IResults, ISaveResults
    {
        private readonly ApplicationDbContext _context;
        public ResultService(ApplicationDbContext _contex) { 
            this._context = _contex;
        }
        public async Task<bool> AddResult(ProfileMatchingResult Result)
        {
            try
            {
                _context.ProfileMatchingResults.Add(Result);
                await _context.SaveChangesAsync();
                return true;
            }catch (Exception)
            {
                return false;
            }
        }
        public async Task<List<ProfileMatchingResult>> GetResults()
        {
            // This should be unsafe since it sends out every detail for the user
            return await _context.ProfileMatchingResults
               .Include(pfm => pfm.Application)
               .ThenInclude(app => app.JobPosition)
               .Include(pfm => pfm.Application)
               .ThenInclude(app => app.Applicant)
               .ToListAsync();

            // Can't get the DTO of applicant only
            /*return await _context.ProfileMatchingResults
               .Include(pfm => pfm.Application)
               .ThenInclude(app => app.JobPosition)
               .Include(pfm => pfm.Application)
               .ThenInclude(app => app.Applicant as Applicant)
               .ToListAsync();*/
        }
    }
}
