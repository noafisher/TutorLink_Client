using System.Windows.Input;
using TutorLinkClient.Models;
using TutorLinkClient.Services;
using TutorLinkClient.Views;

namespace TutorLinkClient.ViewModels;

public class RegisterViewModel : ViewModelBase
{
    //all users

    #region FirstName
    private bool showFirstNameError;

    public bool ShowFirstNameError
    {
        get => showFirstNameError;
        set
        {
            showFirstNameError = value;
            OnPropertyChanged("ShowFirstNameError");
        }
    }

    private string firstName;

    public string FirstName
    {
        get => firstName;
        set
        {
            firstName = value;
            ValidateFirstName();
            OnPropertyChanged("FirstName");
        }
    }

    private string firstNameError;

    public string FirstNameError
    {
        get => firstNameError;
        set
        {
            firstNameError = value;
            OnPropertyChanged("FirstNameError");
        }
    }

    private void ValidateFirstName()
    {
        this.ShowFirstNameError = string.IsNullOrEmpty(FirstName);
    }
    #endregion
    #region LastName
    private bool showLastNameError;

    public bool ShowLastNameError
    {
        get => showLastNameError;
        set
        {
            showLastNameError = value;
            OnPropertyChanged("ShowLastNameError");
        }
    }

    private string lastName;

    public string LastName
    {
        get => lastName;
        set
        {
            lastName = value;
            ValidateLastName();
            OnPropertyChanged("LastName");
        }
    }

    private string lastNameError;

    public string LastNameError
    {
        get => lastNameError;
        set
        {
            lastNameError = value;
            OnPropertyChanged("LastNameError");
        }
    }

    private void ValidateLastName()
    {
        this.ShowLastNameError = string.IsNullOrEmpty(LastName);
    }
    #endregion

    private string email;
    public string Email { get { return email; } set { email = value; OnPropertyChanged(); } }

    private string password;
    public string Password { get { return password; } set { password = value; OnPropertyChanged(); } }

    
    
    private string address;
    public string Address { get { return address; } set { address = value; OnPropertyChanged(); } }

    //student only
    private int currentClass;
    public int CurrentClass { get { return currentClass; }
                              set { currentClass = value; OnPropertyChanged(); } }

    //teacher only
    private double maxDistance;
    public double MaxDistance { get { return maxDistance; } set { maxDistance= value; OnPropertyChanged(); } }

    private bool goToStudent;
    private bool teachAtHome;
    private int vetek;
    private int pricePerHour;

    //Other properties
    private bool isStudent;


    public bool IsStudent { get { return isStudent; } set { isStudent = value; OnPropertyChanged(); } }

    public ICommand GoBackCommand;
    public ICommand RegisterCommand { get; }


    private TutorLinkWebAPIProxy proxy;
    private IServiceProvider serviceProvider;
    public RegisterViewModel(TutorLinkWebAPIProxy proxy, IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        this.proxy = proxy;
        GoBackCommand = new Command(OnGoBack);
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
        if (!isStudent)
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
}