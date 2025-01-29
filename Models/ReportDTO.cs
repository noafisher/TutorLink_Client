using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorLinkClient.Models
{
    public class ReportDTO
    {
        public int ReportId { get; set; }
        public int TeacherId { get; set; }
        public int StudentId { get; set; }
        public bool ReportedByStudent { get; set; }
        public string? ReportText { get; set; }
    }
}
