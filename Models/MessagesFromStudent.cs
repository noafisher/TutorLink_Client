namespace TutorLinkClient.Models
{
    public class MessagesFromStudent
    {
        public StudentDTO Student { get; set; }
        public List<ChatMessageDTO> Messages { get; set; }
    }
}
