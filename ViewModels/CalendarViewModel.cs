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
			GetAllLessons();
			OnPropertyChanged();
		}	
	}
	private ObservableCollection<DateTime> dates;
	public ObservableCollection<DateTime> Dates
	{
        get { return dates; }
        set
        {
            dates = value;
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



	public ICommand GoToAddLessonCommand { get; set; }
	public CalendarViewModel(TutorLinkWebAPIProxy proxy, IServiceProvider serviceProvider)
	{
		this.proxy = proxy;
		this.serviceProvider = serviceProvider;
		LessonsList = new ObservableCollection<Lesson>();
		Dates = new ObservableCollection<DateTime>();
        SelectedDate = DateTime.Now.Date;
        GetAllLessons();
        GoToAddLessonCommand = new Command(GoToAddLesson);
	}


    public Command RefreshCommand => new Command(Refresh);
    public void Refresh()
    {
        GetAllLessons();
    }
	//
    private async void GetAllLessons()
	{
        InServerCall = true;
        //create a fictive lesson
        DateOnly date = DateOnly.FromDateTime(SelectedDate);

        //get all lessons for the selected date
        List<Lesson> l = await proxy.GetAllLessonsAsync(date);
        List<Lesson> result = new List<Lesson>();
        if (l != null)
		{
            for (int i = 0; i < 24; i++)
            {
                Lesson fictive = new Lesson();
                Lesson? current = l.Where(s => s.TimeOfLesson.Hour == i).FirstOrDefault();

                if (current == null)
                {
                    TimeOnly t = new TimeOnly(i, 0);
                    current = new Lesson()
                    {

                        TimeOfLesson = new DateTime(date, t)
                    };

                }
                result.Add(current);
            }
        }
		
		LessonsList = new ObservableCollection<Lesson>(result);
        InServerCall = false;
    }

    private void GoToAddLesson()
    {
        // Navigate to the add lesson View page
		((App)Application.Current).MainPage.Navigation.PushAsync(serviceProvider.GetService<AddLesson>());	
        
    }
}