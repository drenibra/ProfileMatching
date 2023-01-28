using ProfileMatching.Models;

namespace ProfileMatching.ProfileMatchLayer.Applicants
{
    public interface IApplicantService
    {
        Task<List<Applicant>> GetApplicants();

        Task<Applicant> getApplicantById(int id);
        Task<string> AddApplicant(Applicant applicant);

        Task<string> DeleteApplicant(int id);
    }
}