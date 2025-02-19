using System.Collections.ObjectModel;
using System.Windows.Input;
using TutorLinkClient.Models;
using TutorLinkClient.Services;
using TutorLinkClient.Views;
namespace TutorLinkClient.ViewModels;

public class CalendarViewModel : ViewModelBase
{

    private TutorLinkWebAPIProxy proxy;
    private IServiceProvider serviceProvider;

    // properties 
    private DateTime selectedDate;
	public DateTime SelectedDate
    {
		get { return selectedDate; }
		set 
		{
            selectedDate = value;
			OnPropertyChanged();
		}	
	}
	private ObservableCollection<Lesson> lessonsList;

    public ObservableCollection<Lesson> LessonsList 
	{
        get { return lessonsList; }
        set
        {
            lessonsList = value;
            OnPropertyChanged();
        }
    }

	public ICommand GoToAddLessinCommand { get; set; }
	public CalendarViewModel(TutorLinkWebAPIProxy proxy, IServiceProvider serviceProvider)
	{
		this.proxy = proxy;
		this.serviceProvider = serviceProvider;
		LessonsList = new ObservableCollection<Lesson>();
		GetAllLessons();
	}

	//
    private async void GetAllLessons()
	{
		//create a fictive lesson
		Lesson fictive = new Lesson()
		{
			
		};
	}
}