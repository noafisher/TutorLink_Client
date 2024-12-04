using Microsoft.Extensions.DependencyInjection;
using TutorLinkClient.Services;
using TutorLinkClient.Models;
using System.Windows.Input;
using Microsoft.Win32;
using TutorLinkClient.Views;

namespace TutorLinkClient.ViewModels;

public class LoginViewModel : ViewModelBase
{
	private string email;
	private string password;
    private bool teacherOrStudent;


    public string Email{ get { return email; } set { email = value; OnPropertyChanged(); } }
	public string Password{ get { return password; } set { password = value; OnPropertyChanged(); } }
    public bool TeacherOrStudent { get { return teacherOrStudent; } set { teacherOrStudent = value; OnPropertyChanged(); } }
    public ICommand LoginCommand { get; set; }
    public ICommand RegisterCommand { get; }


    private TutorLinkWebAPIProxy proxy;
    private IServiceProvider serviceProvider;
	public LoginViewModel(TutorLinkWebAPIProxy proxy, IServiceProvider serviceProvider)
	{
        this.serviceProvider = serviceProvider;
        this.proxy = proxy;
		LoginCommand = new Command(OnLogin);
        RegisterCommand = new Command(OnRegister);
        ErrorMsg = "";
        Email = "";
        Password = "";
        InServerCall = false;
    }

    private string errorMsg;
    public string ErrorMsg { get { return errorMsg; } set { errorMsg = value; OnPropertyChanged(nameof(ErrorMsg)); } }
    
    private async void OnLogin()
        {
        //Choose the way you want to blobk the page while indicating a server call
        InServerCall = true;
        ErrorMsg = "";
        //Call the server to login - teacher 
        if (!TeacherOrStudent)
        {
            LoginInfoDTO loginInfo = new LoginInfoDTO { Email = Email, Password = Password };
            TeacherDTO? u = await this.proxy.LoginTeacherAsync(loginInfo);
            InServerCall = false;
            ((App)Application.Current).LoggedInTeacher = u;

            //Set the application logged in user to be whatever user returned (null or real user)

            if (u == null)
            {
                ErrorMsg = "Invalid email or password";
            }
            else
            {
                ErrorMsg = "";
                //Navigate to the main page
                //AppShell shell = serviceProvider.GetService<AppShell>();
                //TasksViewModel tasksViewModel = serviceProvider.GetService<TasksViewModel>();
                ////tasksViewModel.Refresh(); //Refresh data and user in the tasksview model as it is a singleton
                //((App)Application.Current).MainPage = shell;
                //Shell.Current.FlyoutIsPresented = false;
                //close the flyout
                //Shell.Current.GoToAsync("Tasks"); //Navigate to the Tasks tab page
            }
        }

        //Call the server to login - student
        else
        {
            LoginInfoDTO loginInfo = new LoginInfoDTO { Email = Email, Password = Password };
            StudentDTO? u = await this.proxy.LoginStudentAsync(loginInfo);
            InServerCall = false;
            ((App)Application.Current).LoggedInStudent = u;
            if (u == null)
            {
                ErrorMsg = "Invalid email or password";
            }
            else
            {
                ErrorMsg = "";
                //Navigate to the main page
                //AppShell shell = serviceProvider.GetService<AppShell>();
                //TasksViewModel tasksViewModel = serviceProvider.GetService<TasksViewModel>();
                ////tasksViewModel.Refresh(); //Refresh data and user in the tasksview model as it is a singleton
                //((App)Application.Current).MainPage = shell;
                //Shell.Current.FlyoutIsPresented = false;
                //close the flyout
                //Shell.Current.GoToAsync("Tasks"); //Navigate to the Tasks tab page
            }

        }

        //Set the application logged in user to be whatever user returned (null or real user)

       
    }

    private void OnRegister()
    {
        ErrorMsg = "";
        Email = "";
        Password = "";
        // Navigate to the Register View page
        ((App)Application.Current).MainPage.Navigation.PushAsync(serviceProvider.GetService<Register>());
    }



}