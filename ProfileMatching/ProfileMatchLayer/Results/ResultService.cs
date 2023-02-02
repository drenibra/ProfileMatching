using Microsoft.EntityFrameworkCore;
using ProfileMatching.Configurations;
using ProfileMatching.Models;
using ProfileMatching.ProfileMatchLayer.Applicants;
using ProfileMatching.ProfileMatchLayer.Applications;
using ProfileMatching.ProfileMatchLayer.Results.Helpers;
using ProfileMatching.RecruiterServices.JobPositions;

namespace ProfileMatching.ProfileMatchLayer.Results
{
    public class ResultService: IResults,ISaveResults
    {
        private readonly ApplicationDbContext _contex;
        public ResultService(ApplicationDbContext _contex) { 
            this._contex = _contex;
        }

        public async Task<bool> AddResult(ProfileMatchingResult Result)
        {
            try
            {
                _contex.ProfileMatchingResults.Add(Result);
                await _contex.SaveChangesAsync();
                return true;
            }catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<ProfileMatchingResult>> GetResults()
        {
            return await _contex.ProfileMatchingResults.ToListAsync();            
        }
    }
}
