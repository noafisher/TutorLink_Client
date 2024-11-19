using TutorLinkClient.ViewModels;
using TutorLinkClient.Views;
using TutorLinkClient.Models;


namespace TutorLinkClient
{
    public partial class App : Application
    {
        public UserDTO? LoggedInUser { get; set; }

        public App(RegisterViewModel vm)
        {

            //MainPage = new AppShell();
            MainPage = new Register(vm);
            LoggedInUser = null;
            InitializeComponent();

        }
    }
}
