using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ProfileMatching.Models
{
    public class Recruiter : AppUser
    {
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public DateTime DateStarted { get; set; }
    }
}
