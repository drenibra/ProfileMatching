using System.ComponentModel.DataAnnotations.Schema;

namespace ProfileMatching.Models
{
    public class ProfileMatchingResult
    {
        public int Id { get; set; }
        public double Result { get; set; }
        public int ApplicationId { get; set; }
        public Application Application { get; set; }

        /*public JobPosition JobPosition { get; set; }
        [ForeignKey("JobPositionId")]
        public int? JobPositionId { get; set; }*/
    }
}
