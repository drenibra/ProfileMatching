using Microsoft.EntityFrameworkCore;
using ProfileMatching.Models;

namespace ProfileMatching.Configurations
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Company> companies { get; set; }
        public DbSet<JobPosition> jobPositions { get; set; }
        public DbSet<Applicant> applicants { get; set; }
        public DbSet<Application> applications { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Word> WordDocs { get; set; }
        public DbSet<ProfileMatchingResult> ProfileMatchingResults { get; set; }

    }
}
