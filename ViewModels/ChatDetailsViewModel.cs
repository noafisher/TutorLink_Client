using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorLinkClient.Models;

namespace TutorLinkClient.ViewModels
{
    [QueryProperty("Messages", "messages")]
    [QueryProperty("TheStudent", "student")]
    [QueryProperty("TheTeacher", "teacher")]
    public class ChatDetailsViewModel:ViewModelBase
    {
        private ObservableCollection<ChatMessageDTO> messages;
        public ObservableCollection<ChatMessageDTO> Messages
        {
            get { return messages; }
            set { messages = value; OnPropertyChanged(); }
        }

        private StudentDTO theStudent;
        public StudentDTO TheStudent
        {
            get { return theStudent; }
            set { theStudent = value; OnPropertyChanged(); }
        }

        private TeacherDTO theTeacher;
        public TeacherDTO TheTeacher
        {
            get { return theTeacher; }
            set { theTeacher = value; OnPropertyChanged(); }
        }

        private string newMessage;
        public string NewMessage
        {
            get { return newMessage; }
            set { newMessage = value; OnPropertyChanged(); }
        }

        public string ChatWithName
        {
            get
            {
                AppShellViewModel vm = (AppShellViewModel)(Shell.Current.BindingContext);
                if (vm.IsStudent)
                {
                    return TheTeacher.DisplayName;
                }
                else
                {
                    return TheStudent.DisplayName;
                }
            }
        }
        public Command SendCommand { get; set; }
        private void OnSend()
        {
            AppShellViewModel vm = (AppShellViewModel)(Shell.Current.BindingContext);

            ChatMessageDTO message = new ChatMessageDTO()
            {
                StudentId = TheStudent.StudentId,
                TeacherId = TheTeacher.TeacherId,
                IsTeacherSender = vm.IsTeacher,
                MessageText = NewMessage,
                TextTime = DateTime.Now,
            };

            vm.SendMessage(message);
            Messages.Add(message);
        }

        public ChatDetailsViewModel()
        {
            SendCommand = new Command(OnSend);
            Messages = new ObservableCollection<ChatMessageDTO>();
            TheStudent = new StudentDTO();
            TheTeacher = new TeacherDTO();
        }
    }
}
