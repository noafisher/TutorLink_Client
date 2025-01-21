using System.Collections.ObjectModel;
using System.Windows.Input;
using TutorLinkClient.Models;
using TutorLinkClient.Services;
using TutorLinkClient.Views;

namespace TutorLinkClient.ViewModels;

public class RateTeacherViewModel : ViewModelBase
{
    private TutorLinkWebAPIProxy proxy;
    private IServiceProvider serviceProvider;

    private string teacherName;
    private string studentName;
    private int stars;
    private string reviewText;
    private ICommand rateTeacher;

    public string TeacherName { get; set; }
    public string StudentName { get; set; }
    public int Stars { get; set; }
    public string ReviewText { get; set; }
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


    public RateTeacherViewModel(TutorLinkWebAPIProxy proxy, IServiceProvider serviceProvider)
	{
        this.serviceProvider = serviceProvider;
        this.proxy = proxy;
        InServerCall = false;

    }

    private async void GetAllTeachers()
    {
        List<TeacherDTO> l = await proxy.GetAllTeachers();


        foreach (TeacherDTO t in l)
        {
            TeachersList.Add(t);

            }
        }
    }

    public async void Rate()
    {
        InServerCall = true;
        try
        {

        int teacherId = SelectedTeacher.TeacherID;             
            ReviewDTO reviewdto = new ReviewDTO()
            {
                    
            };

            
        }
        catch (Exception)
        {
        }

    }
}