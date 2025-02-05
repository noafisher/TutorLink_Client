using System.Collections.ObjectModel;

namespace TutorLinkClient.Models
{
    public class MessagesFromStudent
    {
        public StudentDTO Student { get; set; }
        public ObservableCollection<ChatMessageDTO> Messages { get; set; }
    }


}
