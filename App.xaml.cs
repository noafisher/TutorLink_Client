using TutorLinkClient.ViewModels;
using TutorLinkClient.Views;
using TutorLinkClient.Models;
using System.Reflection;
using TutorLinkClient.Services;


namespace TutorLinkClient
{
    public partial class App : Application
    {
        public TeacherDTO? LoggedInTeacher { get; set; }
        public StudentDTO? LoggedInStudent { get; set; }

        public List<SubjectDTO> Subjects { get; set; }
        public App(IServiceProvider serviceProvider, TutorLinkWebAPIProxy proxy)
        {
            NullabilityInfoContext context = new NullabilityInfoContext();
            
            InitializeComponent();
            //MainPage = new AppShell();
            MainPage = new NavigationPage(serviceProvider.GetService<Login>());
            LoggedInTeacher = null;
            LoggedInStudent = null;
            Subjects = new List<SubjectDTO>();
            LoadDataFromServer(proxy);

        }

        private async void LoadDataFromServer(TutorLinkWebAPIProxy proxy)
        {
            List<SubjectDTO>? list = await proxy.GetAllSubjects();
            if (list != null)
                Subjects = list;
        }
    }
}
