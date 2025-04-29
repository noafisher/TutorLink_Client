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
        public bool IsProcessed { get; set; }
        public StudentDTO Student { get; set; }
        public TeacherDTO Teacher { get; set; }

        public ReportDTO() { }

        public string ImageURL
        {
            get
            {
                if (this.ReportedByStudent)
                    return this.Teacher.ImageURL;
                else 
                    return this.Student.ImageURL;
            }
        }

        public string DisplayName
        {
            get
            {
                if (this.ReportedByStudent)
                    return this.Teacher.DisplayName;
                else
                    return this.Student.DisplayName;
            }
        }



    }
}
