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
        

    }
}
