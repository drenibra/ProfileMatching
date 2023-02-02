namespace ProfileMatching.Models.DTOs
{
    public class JobPositionDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string SkillSet { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int companyId { get; set; }
        public string  category { get; set; }

    }
}
