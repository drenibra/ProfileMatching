using ProfileMatching.Models;

namespace ProfileMatching.RecruiterServices.JobPositions
{
    public interface IGetJobPosition
    {
        JobPosition GetJobPositionById(int id);
    }
}
