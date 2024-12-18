using TutorLinkClient.ViewModels;
using TutorLinkClient.Views;
using TutorLinkClient.Models;


namespace TutorLinkClient
{
    public partial class App : Application
    {
        public TeacherDTO? LoggedInTeacher { get; set; }
        public StudentDTO? LoggedInStudent { get; set; }


        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            //MainPage = new AppShell();
            MainPage = new NavigationPage(serviceProvider.GetService<Login>());
            LoggedInTeacher = null;
            LoggedInStudent = null;
            

        }
    }
}
