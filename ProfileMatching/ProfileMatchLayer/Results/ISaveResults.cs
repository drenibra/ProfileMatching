using ProfileMatching.Models;

namespace ProfileMatching.ProfileMatchLayer.Results
{
    public interface ISaveResults
    {
        public Task<bool> AddResult(ProfileMatchingResult Result);
    }
}
