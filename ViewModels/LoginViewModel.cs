using Microsoft.Extensions.DependencyInjection;
using TutorLinkClient.Services;
using TutorLinkClient.Models;

namespace TutorLinkClient.ViewModels;

public class LoginViewModel : ViewModelBase
{
	private string email;
	private string password;

	public string Email{ get { return email; } set { email = value; OnPropertyChanged(); } }
	public string Password{ get { return password; } set { password = value; OnPropertyChanged(); } }
    public Command LoginCommand { get; set; }

	private TutorLinkWebAPIProxy proxy;
    private IServiceProvider serviceProvider;
	public LoginViewModel(TutorLinkWebAPIProxy proxy)
	{
		this.proxy = proxy;
		LoginCommand = new Command(OnLogin);
	}

    private string errorMsg;
    public string ErrorMsg
    {
        get { return email; }
        set { email = value; OnPropertyChanged(); }
    }
    private async void OnLogin()
        {
        //Choose the way you want to blobk the page while indicating a server call
        InServerCall = true;
        ErrorMsg = "";
        //Call the server to login
        LoginInfoDTO loginInfo = new LoginInfoDTO { Email = Email, Pass = Password };
        UserDTO? u = await this.proxy.LoginAsync(loginInfo);

        InServerCall = false;

        //Set the application logged in user to be whatever user returned (null or real user)
        ((App)Application.Current).LoggedInUser = u;
        if (u == null)
        {
            ErrorMsg = "Invalid email or password";
        }
        else
        {
            ErrorMsg = "";
            //Navigate to the main page
            AppShell shell = serviceProvider.GetService<AppShell>();
            //TasksViewModel tasksViewModel = serviceProvider.GetService<TasksViewModel>();
            //tasksViewModel.Refresh(); //Refresh data and user in the tasksview model as it is a singleton
            ((App)Application.Current).MainPage = shell;
            Shell.Current.FlyoutIsPresented = false; //close the flyout
            //Shell.Current.GoToAsync("Tasks"); //Navigate to the Tasks tab page
        }
    }


}