namespace TutorLinkClient.Models
{
    public class MessagesFromTeacher
    {
        public TeacherDTO Teacher { get; set; }
        public List<ChatMessageDTO> Messages { get; set; }

    }
}
