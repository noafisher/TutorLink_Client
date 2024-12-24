using TutorLinkClient.Models;
using TutorLinkClient.ViewModels;

namespace TutorLinkClient 

{
    public partial class AppShell : Shell
    {
        public AppShell(AppShellViewModel vm)
        {
           this.BindingContext = vm;
            InitializeComponent();
        }
    }
}
