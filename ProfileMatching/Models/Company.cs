namespace ProfileMatching.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Logo { get; set; }
        public virtual ICollection<Recruiter> Recruiters { get; set;}
        public virtual ICollection<JobPosition> JobPositions { get; set; }
    }
}