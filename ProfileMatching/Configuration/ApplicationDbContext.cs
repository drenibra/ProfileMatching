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

    }
}
