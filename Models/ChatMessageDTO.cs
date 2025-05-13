using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TutorLinkClient.Models
{
    public class ChatMessageDTO
    {
        public int MessageId { get; set; }

        public int TeacherId { get; set; }

        public int StudentId { get; set; }

        public bool IsTeacherSender { get; set; }

        public string? MessageText { get; set; }

        public DateTime TextTime { get; set; }

        public bool IsSender
        {
            get
            {
                TeacherDTO? t = ((App)Application.Current).LoggedInTeacher;
                StudentDTO? s = ((App)Application.Current).LoggedInStudent;

                return (t != null && IsTeacherSender) ||
                    (s != null && !IsTeacherSender);
            }
        }

        public bool IsNotSender
        {
            get
            {
                return !IsSender;
            }
        }




    }
}
