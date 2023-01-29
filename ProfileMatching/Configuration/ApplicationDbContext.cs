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
        public DbSet<Company> companies { get; set; }
        public DbSet<JobPosition> jobPositions { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }
    }
}
