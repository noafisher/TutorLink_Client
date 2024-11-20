using TutorLinkClient.ViewModels;
using TutorLinkClient.Views;
using TutorLinkClient.Models;


namespace TutorLinkClient
{
    public partial class App : Application
    {
        public UserDTO? LoggedInUser { get; set; }

        public App( LoginViewModel vm)
        {

            //MainPage = new AppShell();
            MainPage = new Login(vm);
            LoggedInUser = null;
            InitializeComponent();

        }
    }
}
