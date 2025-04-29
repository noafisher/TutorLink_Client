using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorLinkClient.Models;
using TutorLinkClient.Services;
using TutorLinkClient.Views;
namespace TutorLinkClient.ViewModels
{
    public class AppShellViewModel : ViewModelBase
    {
        public bool IsAdmin
        {
            get
            {
                if (IsTeacher)
                {
                    return ((App)Application.Current).LoggedInTeacher.IsAdmin;
                }
                else
                    return ((App)Application.Current).LoggedInStudent.IsAdmin;
            }
        }
        public bool IsTeacher { get; set; }
        public bool IsStudent { get => !IsTeacher; }
        private IServiceProvider serviceProvider;
        private ChatProxy chatProxy;
        private int userId;
        public AppShellViewModel(IServiceProvider serviceProvider, ChatProxy chatProxy)
        {
            this.chatProxy = chatProxy;
            this.serviceProvider = serviceProvider;
            IsTeacher = ((App)Application.Current).LoggedInTeacher != null;
            if (IsTeacher)
                userId = ((App)Application.Current).LoggedInTeacher.TeacherId;
            else
                userId = ((App)Application.Current).LoggedInStudent.StudentId;
            MessagesFromStudent = new ObservableCollection<MessagesFromStudent>();
            MessagesFromTeacher = new ObservableCollection<MessagesFromTeacher>();
            ConnectToChatServer();
            
        }

        

        //this command will be used for logout menu item
        public Command LogoutCommand
        {
            get
            {
                return new Command(OnLogout);
            }
        }
        //this method will be trigger upon Logout button click
        public async void OnLogout()
        {
            await chatProxy.Disconnect(IsTeacher);
            ((App)Application.Current).LoggedInTeacher = null;
            ((App)Application.Current).LoggedInStudent = null;

            ((App)Application.Current).MainPage = new NavigationPage(serviceProvider.GetService<Login>());
        }

        //All Chat Data
        public async void SendMessage(ChatMessageDTO message)
        {
            if (IsStudent)
            {
                await this.chatProxy.SendMessageToTeacher(message.StudentId.ToString(), message.TeacherId.ToString(), message.MessageText);
            }
            else
            {
                await this.chatProxy.SendMessageToStudent(message.StudentId.ToString(), message.TeacherId.ToString(), message.MessageText);
            }

        }
        private async Task ConnectToChatServer()
        {
            if (IsStudent)
            {
                List<MessagesFromTeacher> messages = await chatProxy.StudentConnect(this.userId.ToString());
                MessagesFromTeacher = new ObservableCollection<MessagesFromTeacher>(messages);
                chatProxy.RegisterToReceiveMessageFromTeacher(ReceiveMessageFromTeacher);
            }
            else
            {
                List<MessagesFromStudent> messages = await chatProxy.TeacherConnect(this.userId.ToString());
                MessagesFromStudent = new ObservableCollection<MessagesFromStudent>(messages);
                chatProxy.RegisterToReceiveMessageFromStudent(ReceiveMessageFromStudent);
            }
        }

        public ObservableCollection<MessagesFromStudent> MessagesFromStudent { get; set; }
        public ObservableCollection<MessagesFromTeacher> MessagesFromTeacher { get; set; }

        public void ReceiveMessageFromStudent(StudentDTO student,  ChatMessageDTO message)
        {
            //Find the student in the Messages list and if not exist, add a new one
            MessagesFromStudent? theStudentMessages = MessagesFromStudent.Where(m => m.Student.StudentId == student.StudentId).FirstOrDefault(); 
            if (theStudentMessages == null)
            {
                theStudentMessages = new MessagesFromStudent()
                {
                    Student = student,
                    Messages = new ObservableCollection<ChatMessageDTO>()
                };
            }
            theStudentMessages.Messages.Add(message);

        }

        public void ReceiveMessageFromTeacher(TeacherDTO teacher, ChatMessageDTO message)
        {
            //Find the teacher in the Messages list and if not exist, add a new one
            MessagesFromTeacher? theTeacherMessages = MessagesFromTeacher.Where(m => m.Teacher.TeacherId == teacher.TeacherId).FirstOrDefault();
            if (theTeacherMessages == null)
            {
                theTeacherMessages = new MessagesFromTeacher()
                {
                    Teacher = teacher,
                    Messages = new ObservableCollection<ChatMessageDTO>()
                };
            }
            theTeacherMessages.Messages.Add(message);

        }
    }
}

