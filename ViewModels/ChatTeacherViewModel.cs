using System.Collections.ObjectModel;
using System.Windows.Input;
using TutorLinkClient.Models;
using TutorLinkClient.Services;

namespace TutorLinkClient.ViewModels;

public class ChatTeacherViewModel : ViewModelBase
{
	public ChatTeacherViewModel()
    { }

    public ObservableCollection<MessagesFromStudent> Messages
    {
        get
        { return ((AppShellViewModel)(Shell.Current.BindingContext)).MessagesFromStudent; }
    }

    private MessagesFromStudent selectedStudent;
    public MessagesFromStudent SelectedStudent
    {
        get { return selectedStudent; }
        set
        {
            selectedStudent = value;
            OnGoToChat();
            OnPropertyChanged();
        }
    }

    private ICommand goToChatCommand;
    public ICommand GoToChatCommand
    {
        get { return goToChatCommand; }
        set
        {
            goToChatCommand = value;
            OnPropertyChanged();
        }
    }

    private TutorLinkWebAPIProxy proxy;
    private IServiceProvider serviceProvider;

    public ChatTeacherViewModel(TutorLinkWebAPIProxy proxy, IServiceProvider serviceProvider)
    {
        this.proxy = proxy;
        this.serviceProvider = serviceProvider;
        SelectedStudent = null;


    }
    private async void OnGoToChat()
    {
        if (SelectedStudent != null)
        {
            var navParam = new Dictionary<string, object>
            {
                    { "messages", SelectedStudent.Messages },
                    { "student", SelectedStudent.Student},
                    { "teacher", ((App)Application.Current).LoggedInTeacher}
            };
            await Shell.Current.GoToAsync("ChatDetails", navParam);
        }
        
    }
}

