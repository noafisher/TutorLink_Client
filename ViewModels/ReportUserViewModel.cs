using TutorLinkClient.Models;
using TutorLinkClient.Services;
namespace TutorLinkClient.ViewModels;

using System.Collections.ObjectModel;
using System.Windows.Input;
using TutorLinkClient.Views;



public class ReportUserViewModel : ViewModelBase
{
    
    private TutorLinkWebAPIProxy proxy;
    private IServiceProvider serviceProvider;

    #region report text 
    private string reportText;
    public string ReportText
    {
        get
        {
            return reportText;
        }
        set
        {
            reportText = value;
            OnPropertyChanged();
        }

    }

    // validation 
    private bool showTextError;

    public bool ShowTextError
    {
        get => showTextError;
        set
        {
            showTextError = value;
            OnPropertyChanged();
        }
    }
    private string textError;

    public string TextError

    {
        get => textError;
        set
        {
            textError = value;
            OnPropertyChanged();
        }
    }


    #endregion

    #region who is reporting 
    private bool isStudent; 
    public bool IsStudent { get { return isStudent; } set { isStudent = value; OnPropertyChanged(); OnPropertyChanged("IsTeacher"); } }
    public bool IsTeacher { get { return !isStudent; } }
    #endregion

    #region command 
    private ICommand reportUserComaand;
    public ICommand ReportUserComaand {
        get
        {
            return reportUserComaand;
        }
        set
        {
            reportUserComaand = value;
            OnPropertyChanged();
        }
    }
    #endregion

    private string errorMsg;
    public string ErrorMsg { get; set; }

    #region teacher name
    public ObservableCollection<TeacherDTO> TeachersList { get; set; }

    private bool showTeacherNameError;

    public bool ShowTeacherNameError
    {
        get => showTeacherNameError;
        set
        {
            showTeacherNameError = value;
            OnPropertyChanged();
        }
    }
    private string teacherNameError;

    public string TeacherNameError

    {
        get => teacherNameError;
        set
        {
            teacherNameError = value;
            OnPropertyChanged();
        }
    }

    private void ValidateTeacher()
    {
        this.TeacherNameError = "Teacher must be selected";
        this.ShowTeacherNameError = SelectedTeacher == null;
    }

    private TeacherDTO selectedTeacher;
    public TeacherDTO SelectedTeacher
    {
        get
        {
            return selectedTeacher;
        }
        set
        {
            selectedTeacher = value;
            ValidateTeacher();
            OnPropertyChanged();
        }
    }


    #endregion

    #region student name
    public ObservableCollection<StudentDTO> StudentsliST { get; set; }

    private bool showStudentNameError;

    public bool ShowStudentNameError
    {
        get => showStudentNameError;
        set
        {
            showStudentNameError = value;
            OnPropertyChanged();
        }
    }
    private string studentNameError;

    public string   StudentNameError

    {
        get => studentNameError;
        set
        {
            studentNameError = value;
            OnPropertyChanged();
        }
    }

    private void ValidateStudent()
    {
        this.TeacherNameError = "Teacher must be selected";
        this.ShowTeacherNameError = SelectedStudent == null;
    }

    private StudentDTO selectedStudent;
    public StudentDTO SelectedStudent
    {
        get
        {
            return selectedStudent;
        }
        set
        {
            //if (IsStudent)
            //    selectedStudent = ((App)Application.Current).LoggedInStudent;

            selectedStudent = value;
            ValidateStudent();
            OnPropertyChanged();
        }
    }


    #endregion
    public ReportUserViewModel(TutorLinkWebAPIProxy proxy, IServiceProvider serviceProvider)
	{
        this.proxy = proxy;
        this.serviceProvider = serviceProvider;
     

    }

    public async void OnReport()
    {
        InServerCall = true;

        ReportDTO reportDTO = new ReportDTO()
        {
            TeacherId = SelectedTeacher.TeacherId,
            StudentId = SelectedStudent.StudentId,
            ReportText = reportText
        };

        if (isStudent)
        {
            reportDTO.ReportedByStudent = true;
        }

        else
            reportDTO.ReportedByStudent = false;
          
            


        ReportDTO? theReport = await proxy.ReportUserAsync(reportDTO);
        InServerCall = false;

        if (theReport == null)
            await Application.Current.MainPage.DisplayAlert("Error", "Failed to submit a report, try again", "Ok");
        else
        {
            await Application.Current.MainPage.DisplayAlert("Success", "The report was saved successfully!", "Ok");
            SelectedTeacher = null;
            SelectedStudent = null;
            ReportText = null;
        }


    }

}