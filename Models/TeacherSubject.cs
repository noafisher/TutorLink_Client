using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorLinkClient.Models
{
    public class TeacherSubject
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int MinClass { get; set; }

        public int MaxClass { get; set; }

    }
}
