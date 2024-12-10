using TutorLinkClient.ViewModels;
using TutorLinkClient.Views;
using TutorLinkClient.Models;


namespace TutorLinkClient
{
    public partial class App : Application
    {
        public TeacherDTO? LoggedInTeacher { get; set; }
        public StudentDTO? LoggedInStudent { get; set; }


        public App(RegisterViewModel vm)
        {

            //MainPage = new AppShell();
            MainPage = new Register(vm);
            LoggedInTeacher = null;
            LoggedInStudent = null;
            InitializeComponent();

        }
    }
}
