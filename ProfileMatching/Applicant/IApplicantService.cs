using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProfileMatching.Configurations;

namespace ProfileMatching.Applicant
{
    public interface IApplicantService
    {
        Task<List<Models.Applicant>> GetApplicants();

        Task<Models.Applicant> getApplicantById(int id);

        Task<string> DeleteApplicant(int id);
    }
}