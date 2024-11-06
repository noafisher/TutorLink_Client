using TutorLinkClient.ViewModels;
using TutorLinkClient.Views;

namespace TutorLinkClient
{
    public partial class App : Application
    {
        public App(RegisterViewModel vm)
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new Register(vm);
            ////
        }
    }
}
