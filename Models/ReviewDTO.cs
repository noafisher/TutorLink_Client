using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorLinkClient.Models
{
    public class ReviewDTO
    {
        public int ReviewId { get; set; }
        public int TeacherId { get; set; }
        public int StudentId { get; set; }
        public DateTime TimeOfReview { get; set; }
        public string ReviewText { get; set; }
    }
}
