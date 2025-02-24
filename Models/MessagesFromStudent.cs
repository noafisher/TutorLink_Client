using System.Collections.ObjectModel;

namespace TutorLinkClient.Models
{
    public class MessagesFromStudent
    {
        public StudentDTO Student { get; set; }
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
