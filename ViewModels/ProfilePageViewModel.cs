﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorLinkClient.Services;
using TutorLinkClient.Models;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace TutorLinkClient.ViewModels
{
    [QueryProperty("TheStudentObject", "TheStudentObject")]
    [QueryProperty("TheTeacherObject", "TheTeacherObject")]
    public class ProfilePageViewModel : ViewModelBase
    {
        private TutorLinkWebAPIProxy proxy; 
        private IServiceProvider serviceProvider;

        //the student or teacher that the profile page belongs to
        private StudentDTO theStudentObject;
        public StudentDTO TheStudentObject
        {
            get
            {
                return this.theStudentObject;
            }
            set
            {
                theStudentObject = value;
                TheUserObject = theStudentObject;
            }
        }

        private TeacherDTO theTeacherObject;
        public TeacherDTO TheTeacherObject
        {
            get
            {
                return this.theTeacherObject;
            }
            set
            {
                theTeacherObject = value;
                TheUserObject = theTeacherObject;
            }
        }


        //all users
        private Object theUserObject;
        public Object TheUserObject
        {
            get
            {
                return this.theUserObject;
            }
            set
            {
                theUserObject = value;
                InitData();
            }
        }

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
                this.ShowCurrentClassError = false;
        }

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

        #region Subjects
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
        #endregion
        //Other properties
        private bool isAdmin; 
        public bool IsAdmin { get { return isAdmin; } set { isAdmin = value; OnPropertyChanged(); } }


        private bool isStudent;

        public bool IsStudent 
        { get 
          { 
             return isStudent;
          }

          set 
          {
             isStudent = value;
             OnPropertyChanged();
             OnPropertyChanged("IsTeacher");
          } 
        }


        public bool IsTeacher { get { return !isStudent; } }

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


        public ICommand UpdateUser { get; }
        public ICommand UploadPictureCommand { get; }

        private string errorMsg;
        public string ErrorMsg { get { return errorMsg; } set { errorMsg = value; OnPropertyChanged(nameof(ErrorMsg)); } }

        ///Check if the logged in user is admin
        public bool LoggedInUserIsAdmin
        {
            get
            {
                if (IsTeacher)
                {
                    return ((App)Application.Current).LoggedInTeacher.IsAdmin;
                }
                else
                    return ((App)Application.Current).LoggedInStudent.IsAdmin;
            }
        }
        public ProfilePageViewModel(TutorLinkWebAPIProxy proxy, IServiceProvider serviceProvider)
        {
            this.proxy = proxy;
            this.serviceProvider = serviceProvider;
            ErrorMsg = "";
            this.UpdateUser = new Command(OnUpdateUser);
            this.UploadPictureCommand = new Command(OnUploadPhoto);
            if (((App)Application.Current).LoggedInStudent != null)
                TheUserObject = ((App)Application.Current).LoggedInStudent;
            else
                TheUserObject = ((App)Application.Current).LoggedInTeacher;

        }

        //this function will be used to initialize the data of the user that the profile page belongs to
        private void InitData()
        {
            if (TheUserObject is StudentDTO)
            {
                StudentDTO student = (StudentDTO)TheUserObject;
                IsStudent = true;
                IsAdmin = student.IsAdmin;
                FirstName = student.FirstName;
                LastName = student.LastName;
                Email = student.Email;
                Address = student.UserAddress;
                CurrentClass = student.CurrentClass;
                Password = student.Pass;
                PhotoURL = student.ImageURL;
                LocalPhotoPath = null;
                userId = student.StudentId;
            }
            else
            {
                TeacherDTO teacher = (TeacherDTO)TheUserObject;
                IsStudent = false;
                IsAdmin = teacher.IsAdmin;
                FirstName = teacher.FirstName;
                LastName = teacher.LastName;
                Email = teacher.Email;
                Address = teacher.UserAddress;
                Password = teacher.Pass;
                PhotoURL = teacher.ImageURL;
                LocalPhotoPath = null;
                MaxDistance = teacher.MaxDistance;
                GoToStudent = teacher.GoToStudent;
                Vetek = teacher.Vetek;
                TeachAtHome = teacher.TeachAtHome;
                userId = teacher.TeacherId;
                SelectedSubjects = new ObservableCollection<Object>();
                Subjects = new ObservableCollection<SubjectDTO>(((App)Application.Current).Subjects);
                //add the subjects that the teacher has to the selected subjects
                if (teacher.TeacherSubjects != null)
                {
                    foreach (var subject in Subjects)
                    {
                        foreach (var teacherSubject in teacher.TeacherSubjects)
                        {
                            if (subject.SubjectId == teacherSubject.SubjectId)
                            {
                                SelectedSubjects.Add(subject);
                            }
                        }
                    }
                    
                }
            }



        }
        private async void OnUpdateUser()
        {
            if (IsStudent)
            {
                //Call the server to update - student
                await OnUpdateStudent();
            }

            else
            {
                //Call the server to register - teacher 
                await OnUpdateTeacher();
            }

        }

        private int userId;
        private async Task OnUpdateStudent()
        {
            StudentDTO studentDTO = new StudentDTO()
            {
                StudentId = userId,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                UserAddress = Address,
                Pass = Password,
                CurrentClass = CurrentClass,
                ProfileImagePath = "",
                IsAdmin= IsAdmin
            };

            bool success = await proxy.UpdateStudent(studentDTO);


            StudentDTO theStudent = ((App)Application.Current).LoggedInStudent;

            //Set the application logged in user to be whatever user returned (null or real user)

            if (!success)
            {
                ErrorMsg = "Update Failed!";
            }
            else
            {
                ErrorMsg = "The Update Was Successful";
                //check if photo was selected
                if (!string.IsNullOrEmpty(LocalPhotoPath))
                {
                    theStudent = await proxy.UploadProfileImageStudent(LocalPhotoPath);
                    if (theStudent == null)
                    {
                        ErrorMsg = "Update Succeeded but the profile image was not updated!";
                    }
                    
                }
                //Update the logged in user only if this is the user that made updates to himself
                if (((App)Application.Current).LoggedInStudent != null &&
                    theStudent.StudentId == ((App)Application.Current).LoggedInStudent.StudentId)
                {
                    //update the logged in student
                    ((App)Application.Current).LoggedInStudent = theStudent;
                }
                
            }
        }

        private async Task OnUpdateTeacher()
        {
            TeacherDTO teacherDTO = new TeacherDTO()
            {
                TeacherId = userId,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                UserAddress = Address,
                Pass = Password,
                Vetek = Vetek,
                MaxDistance = MaxDistance,
                GoToStudent = GoToStudent,
                TeachAtHome = TeachAtHome,
                ProfileImagePath = "",
                IsAdmin = IsAdmin,
                PricePerHour = PricePerHour
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
            bool success = await proxy.UpdateTeacher(teacherDTO);


            TeacherDTO theTeacher = ((App)Application.Current).LoggedInTeacher;

            //Set the application logged in user to be whatever user returned (null or real user)

            if (!success)
            {
                ErrorMsg = "Update Failed!";
            }
            else
            {
                ErrorMsg = "The Update Was Successful";
                //check if photo was selected
                if (!string.IsNullOrEmpty(LocalPhotoPath))
                {
                    theTeacher = await proxy.UploadProfileImageTeacher(LocalPhotoPath);
                    if (theTeacher == null)
                    {
                        ErrorMsg = "Update Succeeded but the profile image was not updated!";
                    }

                }

                //Update the logged in user only if this is the user that made updates to himself
                if (((App)Application.Current).LoggedInTeacher != null &&
                   theTeacher.TeacherId == ((App)Application.Current).LoggedInTeacher.TeacherId)
                {
                    //update the logged in student
                    ((App)Application.Current).LoggedInTeacher = theTeacher;
                }
            }
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



    }
}
