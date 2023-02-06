namespace ProfileMatching.Models
{
    public class Applicant : AppUser
    {
        public string Skills { get; set; }
        public List<Document> Documents { get; set; }
    }
}
