using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorLinkClient.Models
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public int TeacherId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public DateTime TimeOfLesson { get; set; }

        public string SubjectName
        {
            get
            {
                List<SubjectDTO> subjects = ((App)Application.Current).Subjects;
                SubjectDTO? s = subjects.Where(ss => ss.SubjectId == SubjectId).FirstOrDefault();
                if (s != null)
                {
                    return s.SubjectName;
                }
                else
                    return "Unknown";

            }
        }

        public Lesson() { }
    }
}
