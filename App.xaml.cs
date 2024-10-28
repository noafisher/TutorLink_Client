using TutorLink_Client.ViewModels;
using TutorLink_Client.Views;

namespace TutorLink_Client
{
    public partial class App : Application
    {
        public App(LoginViewModel vm)
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new Login(vm);
        }
    }
}
