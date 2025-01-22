using System.Collections.ObjectModel;
using System.Windows.Input;
using TutorLinkClient.Models;
using TutorLinkClient.Services;
using TutorLinkClient.Views;

namespace TutorLinkClient.ViewModels;
[QueryProperty(nameof(TeacherParam), "selectedTeacher")]
public class RateTeacherViewModel : ViewModelBase
{
    private TutorLinkWebAPIProxy proxy;
    private IServiceProvider serviceProvider;


    private ICommand rateTeacher;
    private string errorMsg;
    private int stars;
    public int Stars 
    { 
        get
        {
            return this.stars;
        } 
        set
        {
            this.stars = value;
            OnPropertyChanged();
        }
    }
    private string reviewText;
    public string ReviewText
    { 
        get
        {
            return this.reviewText;
        }
        set
        {
            this.reviewText = value;
            OnPropertyChanged();
        }
    }
    public string ErrorMsg { get; set; }    
    public ObservableCollection<TeacherDTO> TeachersList { get; set; }
    
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
            OnPropertyChanged();
        }
    }

    private TeacherDTO teacherParam;
    public TeacherDTO TeacherParam
    {
        get
        {
            return teacherParam;
        }
        set
        {
            teacherParam = value;
            OnPropertyChanged();
        }
    }

    
// validation
    #region teacher validation
    private bool showTeacherNameError;

    public bool ShowTeacherNameError
    {
        get => showTeacherNameError;
        set
        {
            showTeacherNameError = value;
            OnPropertyChanged("ShowFirstNameError");
        }
    }
    private string teacherNameError;

    public string TeacherNameError

    {
        get => teacherNameError;
        set
        {
            teacherNameError = value;
            OnPropertyChanged("TeacherNameError");
        }
    }

    private void ValidateTeacher()
    {
        this.TeacherNameError = "Teacher must be selected";
        this.ShowTeacherNameError = SelectedTeacher == null;
    }
    #endregion

    #region starts validation 
    private bool showStarsError;

    public bool ShowStarsError
    {
        get => showStarsError;
        set
        {
            showStarsError = value;
            OnPropertyChanged("ShowStarsError");
        }
    }
    private string starsError;

    public string StarsError

    {
        get => starsError;
        set
        {
            starsError = value;
            OnPropertyChanged("StarsError");
        }
    }

    private void ValidateStars()
    {
        this.TeacherNameError = "Stars must be selected";
        this.ShowTeacherNameError = stars < 1 || stars > 5;
    }
    #endregion

    #region review text validation
    private bool showTextError;

    public bool ShowTextError
    {
        get => showTextError;
        set
        {
            showTextError = value;
            OnPropertyChanged("    public bool ShowTextError\r\n");
        }
    }
    private string textError;

    public string TextError

    {
        get => textError;
        set
        {
            teacherNameError = value;
            OnPropertyChanged("TextError");
        }
    }

    private void ValidateText()
    {
        this.TeacherNameError = "You must write a review";
        this.ShowTeacherNameError = string.IsNullOrEmpty(ReviewText);
    }
    #endregion


    public RateTeacherViewModel(TutorLinkWebAPIProxy proxy, IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        this.proxy = proxy;
        InServerCall = false;
        rateTeacher = new Command(OnRate);
        TeachersList = new ObservableCollection<TeacherDTO>();
        ErrorMsg = "";
        GetAllTeachers();        
    }

    private async void GetAllTeachers()
    {
        List<TeacherDTO> l = await proxy.GetAllTeachers();


        foreach (TeacherDTO t in l)
        {
            TeachersList.Add(t);
            if (t.TeacherId == teacherParam.TeacherId)
                SelectedTeacher = t;

        }
    }

    public async void OnRate()
    {
        InServerCall = true;
        

            int id = SelectedTeacher.TeacherId;
            ReviewDTO reviewdto = new ReviewDTO()
            {
                TeacherId = id,
                StudentId = ((App)Application.Current).LoggedInStudent.StudentId,
                ReviewText = ReviewText,
                TimeOfReview = DateTime.Now,
                Stars = Stars
            };

            ReviewDTO? theReview = await proxy.RateTeacherAsync(reviewdto);
            InServerCall = false;

        if(theReview == null)
            await Application.Current.MainPage.DisplayAlert("Error", "Failed to submit a review, try again", "Ok");
        else
        {
            await Application.Current.MainPage.DisplayAlert("Success", "The Rate was saved successfully!", "Ok");
        }
        

    }

    

   

    
}
