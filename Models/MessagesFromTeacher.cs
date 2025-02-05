using System.Collections.ObjectModel;

namespace TutorLinkClient.Models
{
    public class MessagesFromTeacher
    {
        public TeacherDTO Teacher { get; set; }
        public ObservableCollection<ChatMessageDTO> Messages { get; set; }

    }
}
