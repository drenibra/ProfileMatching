using ProfileMatching.Models;
using ProfileMatching.Models.DTOs;

namespace ProfileMatching.ProfileMatchLayer.Applicants
{
    public interface IApplicantService
    {
        Task<List<Applicant>> GetApplicants();

       // Task<Applicant> getApplicantById(int id);
        Task<string> AddApplicant(ApplicantDTO applicant);

        Task<string> DeleteApplicant(int id);
    }
}