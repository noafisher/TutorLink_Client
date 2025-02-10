using System.Collections.ObjectModel;

namespace TutorLinkClient.Models
{
    public class MessagesFromTeacher
    {
        public TeacherDTO Teacher { get; set; }
        public ObservableCollection<ChatMessageDTO> Messages { get; set; }

        public int NumMessages
        {
            get
            {
                if (Messages == null) { return 0; }
                else return Messages.Count;
            }
        }

    }
}
