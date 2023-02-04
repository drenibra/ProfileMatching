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

        public Company Company { get; set; }
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]


        public AppUser AppUser { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]

        public DateTime CreatedAt { get; set; }
        public DateTime ExpiryDate { get; set; }

        List<Application> Applications { get; set; }
        List<ProfileMatchingResult> ProfileMatchingResults { get; set; } 
    }
}
