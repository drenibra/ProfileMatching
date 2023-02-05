using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProfileMatching.Models;

namespace ProfileMatching.Configurations
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<AppUser>("AppUser")
                .HasValue<Applicant>("Applicant")
                .HasValue<Recruiter>("Recruiter");

            builder.Entity<Recruiter>()
                .HasOne(r => r.Company)
                .WithMany(c => c.Recruiters)
                .HasForeignKey(r => r.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Application>()
                .HasOne(a => a.JobPosition)
                .WithMany(jp => jp.Applications)
                .OnDelete(DeleteBehavior.NoAction);
        }
        public DbSet<Company> companies { get; set; }
        public DbSet<JobPosition> jobPositions { get; set; }
        public DbSet<Application> applications { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Word> WordDocs { get; set; }
        public DbSet<ProfileMatchingResult> ProfileMatchingResults { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
