using ProfileMatching.Models;

namespace ProfileMatching.RecruiterServices.JobPositions
{
    public interface IGetJobPosition
    {
        Task<JobPosition> GetJobPositionById(int id);
    }
}
