using Microsoft.AspNetCore.Identity;

namespace ProfileMatching.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Skills { get; set; }
        public List<Document>? Documents { get; set; }
        public Company? Company { get; set; }
        public DateTime? DateStarted { get; set; }
    }
}
