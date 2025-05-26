using TutorLinkClient.Services;
using TutorLinkClient.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Threading.Tasks;


namespace TutorLinkClient.ViewModels;

public class TeachersListViewModel : ViewModelBase
{
    private TutorLinkWebAPIProxy proxy;
    private IServiceProvider serviceProvider;

    public ObservableCollection<TeacherDTO> TeachersList { get; set; }
    public ObservableCollection<TeacherDTO> FilteredTeachersList { get; set; }
    public ObservableCollection<SubjectDTO> SubjectList { get; set; }

    private int maxPrice;
    public int MaxPrice
    {
        get
        {
            return maxPrice;
        }
        set
        {
            maxPrice = value;
            OnPropertyChanged();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    private int senority;
    public int Senority
    {
        get
        {
            return senority;
        }
        set
        {
            senority = value;
            OnPropertyChanged();
        }
    }

    public TeachersListViewModel(TutorLinkWebAPIProxy proxy, IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        this.proxy = proxy;
        this.GotoChatCommand = new Command<TeacherDTO>(OnGotoChat);
        this.FilterCommand = new Command(Filter);
        this.GotoRateCommand = new Command<TeacherDTO>(OnGotoRate);
        TeachersList = new ObservableCollection<TeacherDTO>();
        FilteredTeachersList = new ObservableCollection<TeacherDTO>();
        SubjectList = new ObservableCollection<SubjectDTO>();
        SubjectList.Add(new SubjectDTO()
        {
            SubjectId = 0,
            SubjectName = "All"
        });
        SelectedSubject = SubjectList[0];
        MaxPrice = 400;
        GetAllTeachers();
        GetAllSubjects();
    }
    //the suject that is being selected by the user to filter the teachers
    private SubjectDTO selectedSubject;
    public SubjectDTO SelectedSubject
    {
        get
        {
            return selectedSubject;
        }
        set
        {
            selectedSubject = value;
            OnPropertyChanged();
        }
    }

    // this function is called when the page is opened and it will get all the subjects from the server and add them to the list of subjects
    private async void GetAllSubjects()
    {
        List<SubjectDTO> l = await proxy.GetAllSubjects();
        foreach (SubjectDTO s in l)
        {
            SubjectList.Add(s);
        }
    }
    // this function is called when the page is opened and it will get all the teachers from the server and add them to the list of teachers
    private async void GetAllTeachers()
    {
        List<TeacherDTO> l   = await proxy.GetAllTeachers();
        

        foreach (TeacherDTO t in l)
        {
            TeachersList.Add(t);
            FilteredTeachersList.Add(t);

            
        }
    }

    public ICommand FilterCommand { get; set; }

    //this function is called when the user clicks on the filter button and it will filter the teachers by the selected subject and the price they chose, also buy the senority of the teacher
    private void Filter()
    {
        FilteredTeachersList.Clear();
        foreach(TeacherDTO t in TeachersList)
        {
            if (SelectedSubject.SubjectId == 0 || t.TeacherSubjects.Where(ss => ss.SubjectId == SelectedSubject.SubjectId).ToList().Count() > 0)
            {
                if (MaxPrice == 0 || t.PricePerHour <= MaxPrice)
                {
                    if(senority == 0 || t.Vetek >= senority)
                    { 
                        FilteredTeachersList.Add(t);
                    }
                }
            }
        }
    }


    // the students can select a teacher and navigate to the chat page with the teacher and start chatting with him
    public ICommand GotoChatCommand { get; set; }
    private async void OnGotoChat(TeacherDTO t)
    {
        try
        {
            ObservableCollection<MessagesFromTeacher> Messages = ((AppShellViewModel)(Shell.Current.BindingContext)).MessagesFromTeacher;
            MessagesFromTeacher? teacher = Messages.Where(m => m.Teacher.TeacherId == t.TeacherId).FirstOrDefault();
            if (teacher == null)
            {
                teacher = new MessagesFromTeacher()
                {
                    Teacher = t,
                    Messages = new ObservableCollection<ChatMessageDTO>()
                };
                Messages.Add(teacher);
            }
            var navParam = new Dictionary<string, object>
            {
                    { "messages", teacher.Messages },
                    { "teacher", teacher.Teacher},
                    { "student", ((App)Application.Current).LoggedInStudent}
            };
            await Shell.Current.GoToAsync("ChatDetails", navParam);

            //await Shell.Current.GoToAsync("//ChatStudent");
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        

    }

    // the students can select a teacher and navigate to the rate page with the teacher and rate him
    public ICommand GotoRateCommand { get; set; }
    private async void OnGotoRate(TeacherDTO t)
    {
        if (t != null)
        {
            var navParam = new Dictionary<string, object>
            {
                    { "selectedTeacher", t }
            };
            await Shell.Current.GoToAsync("//RateTeacher", navParam);
        }
        

    } 
    


}