using ProfileMatching.Models;
using ProfileMatching.Models.DTOs;

namespace ProfileMatching.ProfileMatchLayer.Applications
{
    public interface IApplicationService
    {
        Task<bool> apply(ApplicationDTO application);

        Task<List<Application>> getApplications();

        Task<Application> getApplicationsByJobId(int id);

        Task<string> deleteApplication(int id);
    }
}