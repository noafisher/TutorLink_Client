using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorLinkClient.Views;
namespace TutorLinkClient.ViewModels
{
    public class AppShellViewModel : ViewModelBase
    {
        public bool IsTeacher { get; set; }
        public bool IsStudent { get => !IsTeacher; }
        private IServiceProvider serviceProvider;
        public AppShellViewModel(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            IsTeacher = ((App)Application.Current).LoggedInTeacher != null;
            
        }

        

        //this command will be used for logout menu item
        public Command LogoutCommand
        {
            get
            {
                return new Command(OnLogout);
            }
        }
        //this method will be trigger upon Logout button click
        public void OnLogout()
        {
            ((App)Application.Current).LoggedInTeacher = null;
            ((App)Application.Current).LoggedInStudent = null;

            ((App)Application.Current).MainPage = new NavigationPage(serviceProvider.GetService<Login>());
        }
    }
}

