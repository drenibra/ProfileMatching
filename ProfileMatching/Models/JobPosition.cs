using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfileMatching.Models
{
    public class JobPosition
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SkillSet { get; set; }
        public string Category { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public string RecruiterId { get; set; }
        public Recruiter Recruiter { get; set; }
        public List<Application> Applications { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}