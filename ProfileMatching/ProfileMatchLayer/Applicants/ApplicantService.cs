using Microsoft.EntityFrameworkCore;
using ProfileMatching.Configurations;
using ProfileMatching.Models;
using ProfileMatching.Models.DTOs;
using ProfileMatching.ProfileMatchLayer.Documents;

namespace ProfileMatching.ProfileMatchLayer.Applicants
{
    public class ApplicantService : IApplicantService,IGetApplicant
    {
        private readonly ApplicationDbContext _context;

        public ApplicantService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Applicant>> GetApplicants()
        {
            return await _context.applicants.ToListAsync();
        }

        public Applicant getApplicantById(int id)
        {
            return _context.applicants.FirstOrDefault(applicant => applicant.Id == id);
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

        public async Task<string> AddApplicant(ApplicantDTO applicant)
        {
            Applicant a = new Applicant()
            {
                Name= applicant.Name,
                Skills= applicant.Skills
            };
            _context.applicants.Add(a);
            await _context.SaveChangesAsync();

            return "Aplikanti u shtua me sukses";
        }
    }
}