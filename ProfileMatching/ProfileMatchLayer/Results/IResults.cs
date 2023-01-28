using ProfileMatching.Models;

namespace ProfileMatching.ProfileMatchLayer.Results
{

    public interface IResults
    {
        Task<List<ProfileMatchingResult>> GetApplicants();
    }
}
