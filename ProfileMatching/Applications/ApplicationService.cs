using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProfileMatching.Configurations;
using ProfileMatching.Models;
using Microsoft.EntityFrameworkCore;

namespace ProfileMatching.Applications
{
    public class ApplicationService : IApplicationService
    {
        private readonly ApplicationDbContext _context;
        public ApplicationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Application> apply(Application application)
        {
            _context.applications.Add(application);
            await _context.SaveChangesAsync();
            return application;
        }

        public async Task<string> deleteApplication(int id)
        {
            var result = await _context.applications.FirstOrDefaultAsync(c => c.Id == id);
            if (result != null)
            {
                _context.applications.Remove(result);
                await _context.SaveChangesAsync();
                return "Aplikimi me id=" + id + " u fshi me sukses!";
            }
            return "Nuk ka rezultate per kete aplikim!";
        }

        public async Task<List<Application>> getApplications()
        {
            return await _context.applications.ToListAsync();
        }

        public async Task<Application> getApplicationsByJobId(int id)
        {
            return await _context.applications.FirstOrDefaultAsync(application => application.JobPosition.Id == id);
        }
    }
}