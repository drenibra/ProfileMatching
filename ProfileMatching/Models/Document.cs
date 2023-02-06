using System.ComponentModel.DataAnnotations.Schema;

namespace ProfileMatching.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SavedPath { get; set; }
        public int Size { get; set; }
        public string Extension { get; set; }
        public string ApplicantId { get; set; }
        [ForeignKey("ApplicantId")]
        public Applicant Applicant { get; set; }
        public virtual void Update()
        {

        }
    }
}
