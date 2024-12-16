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

    #region Email
    private bool showEmailError;

    public bool ShowEmailError
    {
        get => showEmailError;
        set
        {
            showEmailError = value;
            OnPropertyChanged("ShowEmailError");
        }
    }

    private string email;

    public string Email
    {
        get => email;
        set
        {
            email = value;
            ValidateEmail();
            OnPropertyChanged("Email");
        }
    }

    private string emailError;

    public string EmailError
    {
        get => emailError;
        set
        {
            emailError = value;
            OnPropertyChanged("EmailError");
        }
    }

    private void ValidateEmail()
    {
        this.ShowEmailError = string.IsNullOrEmpty(Email);
    }
    #endregion

    #region Password
    private bool showPasswordError;

    public bool ShowPasswordError
    {
        get => showPasswordError;
        set
        {
            showPasswordError = value;
            OnPropertyChanged("ShowPasswordError");
        }
    }

    private string password;

    public string Password
    {
        get => password;
        set
        {
            password = value;
            ValidatePassword();
            OnPropertyChanged("Password");
        }
    }

    private string passwordError;

    public string PasswordError
    {
        get => passwordError;
        set
        {
            passwordError = value;
            OnPropertyChanged("PasswordError");
        }
    }

    private void ValidatePassword()
    {
        this.ShowPasswordError = string.IsNullOrEmpty(Password);
    }
    #endregion

    #region Address
    private bool showAddressError;

    public bool ShowAddressError
    {
        get => showAddressError;
        set
        {
            showAddressError = value;
            OnPropertyChanged("ShowAddressError");
        }
    }

    private string address;

    public string Address
    {
        get => address;
        set
        {
            address = value;
            ValidateAddress();
            OnPropertyChanged("Address");
        }
    }

    private string addressError;

    public string AddressError
    {
        get => addressError;
        set
        {
            addressError = value;
            OnPropertyChanged("AddressError");
        }
    }

    private void ValidateAddress()
    {
        this.ShowAddressError = string.IsNullOrEmpty(Address);
    }
    #endregion  

    //student only
    #region CurrentClass
    private bool showCurrentClassError;

    public bool ShowCurrentClassError
    {
        get => showCurrentClassError;
        set
        {
            showCurrentClassError = value;
            OnPropertyChanged("ShowCurrentClassError");
        }
    }

    private int currentClass;

    public int CurrentClass
    {
        get => currentClass;
        set
        {
            currentClass = value;
            ValidateCurrentClass();
            OnPropertyChanged("CurrentClass");
        }
    }

    private int currentClassError;

    public int CurrentClassError
    {
        get => currentClassError;
        set
        {
            currentClassError = value;
            OnPropertyChanged("CurrentClassError");
        }
    }

    private void ValidateCurrentClass()
    {
        if (currentClass < 1 || currentClass > 12)
            this.showCurrentClassError = true;

        else
            this.showCurrentClassError = false; }

    #endregion

    //teacher only

    #region MaxDistance
    private bool showMaxDistanceError;

    public bool ShowMaxDistanceError
    {
        get => showMaxDistanceError;
        set
        {
            showMaxDistanceError = value;
            OnPropertyChanged("ShowMaxDistanceError");
        }
    }

    private double maxDistance;

    public double MaxDistance
    {
        get => maxDistance;
        set
        {
            maxDistance = value;
            ValidateMaxDistance();
            OnPropertyChanged("MaxDistance");
        }
    }

    private string maxDistanceError;

    public string MaxDistanceError
    {
        get => maxDistanceError;
        set
        {
            maxDistanceError = value;
            OnPropertyChanged("MaxDistanceError");
        }
    }

    private void ValidateMaxDistance()
    {
        if (maxDistance < 0)
            this.showMaxDistanceError = true;

        else 
            this.ShowMaxDistanceError = false;
        
    }
    #endregion

    //ולדיציה טיפוס בוליאני
    #region GoToStudent
    private bool showGoToStudentError;

    public bool ShowGoToStudentError
    {
        get => showGoToStudentError;
        set
        {
            showGoToStudentError = value;
            OnPropertyChanged("ShowGoToStudentError");
        }
    }

    private bool goToStudent;

    public bool GoToStudent
    {
        get => goToStudent;
        set
        {
            goToStudent = value;
            ValidateGoToStudent();
            OnPropertyChanged("GoToStudent");
        }
    }

    private bool goToStudentError;

    public bool GoToStudentError
    {
        get => goToStudentError;
        set
        {
            goToStudentError = value;
            OnPropertyChanged("GoToStudentError");
        }
    }

    private void ValidateGoToStudent()
    {
        this.ShowGoToStudentError = false;

    }
    #endregion

    #region TeachAtHome
    private bool showTeachAtHomeError;

    public bool ShowTeachAtHomeError
    {
        get => showTeachAtHomeError;
        set
        {
            showTeachAtHomeError = value;
            OnPropertyChanged("ShowTeachAtHomeError");
        }
    }

    private bool teachAtHome;

    public bool TeachAtHome
    {
        get => teachAtHome;
        set
        {
            teachAtHome = value;
            ValidateTeachAtHome();
            OnPropertyChanged("TeachAtHome");
        }
    }

    private bool teachAtHomeError;

    public bool TeachAtHomeError
    {
        get => teachAtHomeError;
        set
        {
            teachAtHomeError = value;
            OnPropertyChanged("TeachAtHomeError");
        }
    }

    private void ValidateTeachAtHome()
    {
        this.TeachAtHome = false;

    }
    #endregion

    #region Vetek
    private bool showVetekError;

    public bool ShowVetekError
    {
        get => showVetekError;
        set
        {
            showVetekError = value;
            OnPropertyChanged("ShowVetekError");
        }
    }

    private int vetek;

    public int Vetek
    {
        get => vetek;
        set
        {
            vetek = value;
            ValidateVetek();
            OnPropertyChanged("Vetek");
        }
    }

    private int vetekError;

    public int VetekError
    {
        get => vetekError;
        set
        {
            vetekError = value;
            OnPropertyChanged("VetekError");
        }
    }

    private void ValidateVetek()
    {
        if (vetek < 0 || vetek > 50)
            this.showVetekError = true;

        else
            this.showVetekError = false;
    }

    #endregion

    #region PricePerHour
    private bool showPricePerHourError;

    public bool ShowPricePerHourError
    {
        get => showPricePerHourError;
        set
        {
            showPricePerHourError = value;
            OnPropertyChanged("ShowPricePerHourError");
        }
    }

    private int pricePerHour;

    public int PricePerHour
    {
        get => pricePerHour;
        set
        {
            pricePerHour = value;
            ValidatePricePerHour();
            OnPropertyChanged("PricePerHour");
        }
    }

    private int pricePerHourError;

    public int PricePerHourError
    {
        get => pricePerHourError;
        set
        {
            pricePerHourError = value;
            OnPropertyChanged("PricePerHourError");
        }
    }

    private void ValidatePricePerHour()
    {
        if (pricePerHour < 0 || pricePerHour > 250)
            this.showPricePerHourError = true;

        else
            this.showPricePerHourError = false;
    }

    #endregion
    //Other properties
    private bool isStudent;


    public bool IsStudent { get { return isStudent; } set { isStudent = value; OnPropertyChanged(); OnPropertyChanged("IsTeacher"); } }
    public bool IsTeacher { get { return !isStudent; } }

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
        IsStudent = true;
        InServerCall = false;
    }

    private string errorMsg;
    public string ErrorMsg { get { return errorMsg; } set { errorMsg = value; OnPropertyChanged(nameof(ErrorMsg)); } }

    private async void OnRegister()
    {
        InServerCall = true;
        //Call the server to login - teacher 
        if (IsStudent)
        {
            StudentDTO studentDTO = new StudentDTO()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                UserAddress = Address,
                Pass = Password,
                CurrentClass = CurrentClass
            };

            StudentDTO? theStudent = await proxy.RegisterStudentAsync(studentDTO);
            InServerCall = false;
            
            ((App)Application.Current).LoggedInStudent = theStudent;

            //Set the application logged in user to be whatever user returned (null or real user)

            if (theStudent == null)
            {
                ErrorMsg = "Registration Failed! Are you sure you are not registered with this email?";
            }
            else
            {
                ErrorMsg = "";
                OnGoBack();
            }
        }

        //Call the server to register teacher
        else
        {
            TeacherDTO teacherDTO = new TeacherDTO()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                UserAddress = Address,
                Pass = Password,
                MaxDistance = MaxDistance,
                GoToStudent = GoToStudent,
                TeachAtHome = TeachAtHome,
                Vetek = Vetek,
                PricePerHour = PricePerHour

            };

            TeacherDTO? theTeacher = await proxy.RegisterTeacherAsync(teacherDTO);
            InServerCall = false;

            ((App)Application.Current).LoggedInTeacher = theTeacher;

            //Set the application logged in user to be whatever user returned (null or real user)

            if (theTeacher == null)
            {
                ErrorMsg = "Registration Failed! Are you sure you are not registered with this email?";
            }
            else
            {
                ErrorMsg = "";
                OnGoBack();
            }

        }

        //Set the application logged in user to be whatever user returned (null or real user)


    }

    private void OnGoBack()
    {
        // Navigate to the Register View page
        ((App)Application.Current).MainPage.Navigation.PopAsync();
    }


}
