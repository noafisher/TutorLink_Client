using TutorLinkClient.ViewModels;
using TutorLinkClient.Views;
using TutorLinkClient.Models;
using System.Reflection;


namespace TutorLinkClient
{
    public partial class App : Application
    {
        public TeacherDTO? LoggedInTeacher { get; set; }
        public StudentDTO? LoggedInStudent { get; set; }


        public App(IServiceProvider serviceProvider)
        {
            NullabilityInfoContext context = new NullabilityInfoContext();
            
            InitializeComponent();
            //MainPage = new AppShell();
            MainPage = new NavigationPage(serviceProvider.GetService<Login>());
            LoggedInTeacher = null;
            LoggedInStudent = null;
            

        }
    }
}
