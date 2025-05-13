using System.Collections.ObjectModel;
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
        this.FirstNameError = "First Name is required!";
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
        this.LastNameError = "Last Name is required!";
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
        if (!ShowEmailError)
        {
            //check if email is in the correct format using regular expression
            if (!System.Text.RegularExpressions.Regex.IsMatch(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                EmailError = "Email is not valid";
                ShowEmailError = true;
            }
            else
            {
                EmailError = "";
                ShowEmailError = false;
            }
        }
        else
        {
            EmailError = "Email is required";
        }
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

        //Password must include characters and numbers and be longer than 4 characters
        if (string.IsNullOrEmpty(password) ||
            password.Length < 4 ||
            !password.Any(char.IsDigit) ||
            !password.Any(char.IsLetter))
        {
            this.ShowPasswordError = true;
        }
        else
            this.ShowPasswordError = false;
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
        this.AddressError = "Addres is required ";
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

    private string currentClassError;

    public string CurrentClassError
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
        {
            this.ShowCurrentClassError = true;
            this.CurrentClassError = "Class must be between 1 to 12!";
        }
        else
            this.ShowCurrentClassError = false; }

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
        {
            this.ShowMaxDistanceError = true;
            this.MaxDistanceError = "Distance is not valid";
        }

        else
            this.ShowMaxDistanceError = false;
        
    }
    #endregion

    #region GoToStudent
    

    private bool goToStudent;

    public bool GoToStudent
    {
        get => goToStudent;
        set
        {
            goToStudent = value;
            ValidateTeachAt();
            OnPropertyChanged("GoToStudent");
        }
    }

    
    #endregion

    #region TeachAtHome
    private bool showTeachAtError;

    public bool ShowTeachAtError
    {
        get => showTeachAtError;
        set
        {
            showTeachAtError = value;
            OnPropertyChanged();
        }
    }

    private bool teachAtHome;

    public bool TeachAtHome
    {
        get => teachAtHome;
        set
        {
            teachAtHome = value;
            ValidateTeachAt();
            OnPropertyChanged("TeachAtHome");
        }
    }

    private string teachAtError;

    public string TeachAtError
    {
        get => teachAtError;
        set
        {
            teachAtError = value;
            OnPropertyChanged("TeachAtError");
        }
    }

    private void ValidateTeachAt()
    {
        TeachAtError = "You must choose one of the options";
        if (this.TeachAtHome == false && this.GoToStudent == false)
            ShowTeachAtError = true;
        else
            ShowTeachAtError = false;

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

    private string vetekError;

    public string VetekError
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
        if (vetek < 0 || vetek > 70)
        {
            this.ShowVetekError = true;
            this.VetekError = "Check the years that you entered again";
        }
        else
            this.ShowVetekError = false;
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

    private string pricePerHourError;

    public string PricePerHourError
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
        {
            this.ShowPricePerHourError = true;
            this.PricePerHourError = "The price you enter is out of rage";
        }

        else
            this.ShowPricePerHourError = false;
    }

    #endregion

    private ObservableCollection<SubjectDTO> subjects;
    public ObservableCollection<SubjectDTO> Subjects
    {
        get
        {
            return subjects;
        }
        set
        {
            subjects = value;
            OnPropertyChanged();
        }
    }

    private ObservableCollection<Object> selectedSubjects;
    public ObservableCollection<Object> SelectedSubjects
    {
        get
        {
            return selectedSubjects;
        }
        set
        {
            selectedSubjects = value;
            OnPropertyChanged();
        }
    }

    public Command SelectionCommand { get; set; }
    private void OnSelectionChanged()
    {
        
    }
    //Other properties
    private bool isStudent;

    #region Photo

    private string photoURL;

    public string PhotoURL
    {
        get => photoURL;
        set
        {
            photoURL = value;
            OnPropertyChanged("PhotoURL");
        }
    }

    private string localPhotoPath;

    public string LocalPhotoPath
    {
        get => localPhotoPath;
        set
        {
            localPhotoPath = value;
            OnPropertyChanged("LocalPhotoPath");
        }
    }
    #endregion


    public bool IsStudent { get { return isStudent; } set { isStudent = value; OnPropertyChanged(); OnPropertyChanged("IsTeacher"); } }
    public bool IsTeacher { get { return !isStudent; } }

    public ICommand GoBackCommand;
    public ICommand RegisterCommand { get; }
    public ICommand UploadPictureCommand { get; }


    private TutorLinkWebAPIProxy proxy;
    private IServiceProvider serviceProvider;
    public RegisterViewModel(TutorLinkWebAPIProxy proxy, IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        this.proxy = proxy;
        GoBackCommand = new Command(OnGoBack);
        RegisterCommand = new Command(OnRegister);
        UploadPictureCommand = new Command(OnUploadPhoto);
        SelectionCommand = new Command(OnSelectionChanged);
        ErrorMsg = "";
        Email = "";
        Password = "";
        SelectedSubjects = new ObservableCollection<Object>();
        List<SubjectDTO> s = ((App)Application.Current).Subjects;
        Subjects = new ObservableCollection<SubjectDTO>(s);
        InServerCall = false;
    }

    private string errorMsg;
    public string ErrorMsg { get { return errorMsg; } set { errorMsg = value; OnPropertyChanged(nameof(ErrorMsg)); } }

    private async void OnRegister()
    {
        InServerCall = true;
        //Call the server to register - student 
        if (IsStudent)
        {
            await OnRegisterStudent();
        }
        //Call the server to register teacher
        else
        {
            await OnRegisterTeacher();

        }
        InServerCall = false;
    }

    private async Task OnRegisterStudent()
    {
        StudentDTO studentDTO = new StudentDTO()
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            UserAddress = Address,
            Pass = Password,
            CurrentClass = CurrentClass,
            ProfileImagePath = ""
        };

        StudentDTO? theStudent = await proxy.RegisterStudentAsync(studentDTO);
        

        ((App)Application.Current).LoggedInStudent = theStudent;

        //Set the application logged in user to be whatever user returned (null or real user)

        if (theStudent == null)
        {
            ErrorMsg = "Registration Failed! Are you sure you are not registered with this email?";
        }
        else
        {
            ErrorMsg = "";
            //check if photo was selected
            if (!string.IsNullOrEmpty(LocalPhotoPath)) 
            {
                await proxy.LoginStudentAsync(new LoginInfoDTO()
                {
                    Email = theStudent.Email,
                    Password = theStudent.Pass
                });
                theStudent = await proxy.UploadProfileImageStudent(LocalPhotoPath);
                if (theStudent == null)
                {
                    ErrorMsg = "Registration Succeeded but the profile image was not updated!";
                }
                else
                {
                    ((App)Application.Current).LoggedInStudent = theStudent;
                }
            }
            OnGoBack();
        }
    }

    private async Task OnRegisterTeacher()
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
            PricePerHour = PricePerHour,
            ProfileImagePath = ""

        };

        teacherDTO.TeacherSubjects = new List<TeacherSubject>();
        foreach (Object obj in SelectedSubjects)
        {
            if (obj is SubjectDTO)
            {
                SubjectDTO subject = (SubjectDTO)obj;
                teacherDTO.TeacherSubjects.Add(new TeacherSubject()
                {
                    SubjectId = subject.SubjectId,
                    SubjectName = subject.SubjectName,
                    MinClass = 1,
                    MaxClass = 12 //Default value
                });
            }
            
        }
        //Call the server to register - teacher
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
            //check if photo was selected
            if (!string.IsNullOrEmpty(LocalPhotoPath))
            {
                await proxy.LoginTeacherAsync(new LoginInfoDTO()
                {
                    Email = theTeacher.Email,
                    Password = theTeacher.Pass
                });
                theTeacher = await proxy.UploadProfileImageTeacher(LocalPhotoPath);
                if (theTeacher == null)
                {
                    ErrorMsg = "Registration Succeeded but the profile image was not updated!";
                }
                else
                {
                    ((App)Application.Current).LoggedInTeacher = theTeacher;
                }
            }
            OnGoBack();
        }
    }

    private void OnGoBack()
    {
        // Navigate to the Register View page
        ((App)Application.Current).MainPage.Navigation.PopAsync();
    }

    //upload profile picture on the register page
    private async void OnUploadPhoto()
    {
        try
        {
            var result = await MediaPicker.Default.CapturePhotoAsync(new MediaPickerOptions
            {
                Title = "Please select a photo",
            });

            if (result != null)
            {
                // The user picked a file
                this.LocalPhotoPath = result.FullPath;
                this.PhotoURL = result.FullPath;
            }
        }
        catch (Exception ex)
        {
        }

    }

    private void UpdatePhotoURL(string virtualPath)
    {
        Random r = new Random();
        PhotoURL = proxy.GetImagesBaseAddress() + virtualPath + "?v=" + r.Next();
        LocalPhotoPath = "";
    }


}
