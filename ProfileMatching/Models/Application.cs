using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileMatching.Models
{
    public class Application
    {
        public int Id { get; set; }

        public DateTime date { get; set; }


        public int JobPositionId { get; set; }
        public JobPosition JobPosition { get; set; }

        public Applicant Applicant { get; set; }

        [ForeignKey("ApplicantId")]
        public int ApplicantId { get; set; }
    }
}