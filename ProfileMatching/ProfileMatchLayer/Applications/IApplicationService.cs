using ProfileMatching.Models;
using ProfileMatching.Models.DTOs;

namespace ProfileMatching.ProfileMatchLayer.Applications
{
    public interface IApplicationService
    {
        Task<bool> Apply(ApplicationDTO application);

        Task<List<Application>> GetApplications();

        Task<Application> GetApplicationsByJobId(int id);

        Task<string> DeleteApplication(int id);
    }
}