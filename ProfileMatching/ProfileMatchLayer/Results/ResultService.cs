using Microsoft.EntityFrameworkCore;
using ProfileMatching.Configurations;
using ProfileMatching.Models;
using ProfileMatching.ProfileMatchLayer.Users;
using ProfileMatching.ProfileMatchLayer.Applications;
using ProfileMatching.ProfileMatchLayer.Results.Helpers;
using ProfileMatching.RecruiterServices.JobPositions;

namespace ProfileMatching.ProfileMatchLayer.Results
{
    public class ResultService: IResults,ISaveResults
    {
        private readonly ApplicationDbContext _contex;
        public ResultService(ApplicationDbContext contex) { 
            _contex = contex;
        }

        public async Task<bool> AddResult(ProfileMatchingResult Result)
        {
            try
            {
                _contex.ProfileMatchingResults.Add(Result);
                await _contex.SaveChangesAsync();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<List<ProfileMatchingResult>> GetApplicants()
        {
            return await _contex.ProfileMatchingResults.ToListAsync();            
        }
    }
}
