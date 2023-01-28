using System.ComponentModel.DataAnnotations.Schema;

namespace ProfileMatching.Models
{
    public class Applicant
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Skills { get; set; }

        public List<Document> Documents { get; set; }
    }
}
