using Microsoft.EntityFrameworkCore;
using ProfileMatching.Configurations;

namespace ProfileMatching.Applicant
{
    public class ApplicantService : IApplicantService
    {
        private readonly ApplicationDbContext _context;

        public ApplicantService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Models.Applicant>> GetApplicants()
        {
            return await _context.applicants.ToListAsync();
        }

        public async Task<Models.Applicant> getApplicantById(int id)
        {
            return await _context.applicants.FirstOrDefaultAsync(applicant => applicant.Id == id);
        }

        public async Task<string> DeleteApplicant(int id)
        {
            var result = await _context.applicants.FirstOrDefaultAsync(c => c.Id == id);
            if (result != null)
            {
                _context.applicants.Remove(result);
                await _context.SaveChangesAsync();
                return "Aplikuesi me id=" + id + " u fshi me sukses!";
            }
            return "Nuk ka rezultate per kete aplikues!";
        }
    }
}