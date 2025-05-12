using TutorLinkClient.Models;
using TutorLinkClient.ViewModels;
using TutorLinkClient.Views;

namespace TutorLinkClient 

{
    public partial class AppShell : Shell
    {
        public AppShell(AppShellViewModel vm)
        {
           this.BindingContext = vm;
            InitializeComponent();
            Routing.RegisterRoute("ChatDetails", typeof(ChatDetails));
            Routing.RegisterRoute("AdminProfile", typeof(ProfilePage));
        }
    }
}
