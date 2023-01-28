using ProfileMatching.Models;

namespace ProfileMatching.ProfileMatchLayer.Applicants
{
    public interface IGetApplicant
    {
        Applicant getApplicantById(int id);
    }
}
