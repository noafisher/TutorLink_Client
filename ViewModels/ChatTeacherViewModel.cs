using System.Collections.ObjectModel;
using System.Windows.Input;
using TutorLinkClient.Models;
using TutorLinkClient.Services;

namespace TutorLinkClient.ViewModels;

public class ChatTeacherViewModel : ViewModelBase
{
	public ChatTeacherViewModel()
    { }

    private ObservableCollection<MessagesFromStudent> messages;
    public ObservableCollection<MessagesFromStudent> Messages
    {
        get
        { return messages; }
        set
        {
            messages = value;
            OnPropertyChanged();
        }
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
        Messages = ((AppShellViewModel)(Shell.Current.BindingContext)).MessagesFromStudent;
        SelectedStudent = null;


    }
    private void OnGoToChat()
    {
        //TODO: Open the chat details page and transfer the selected object
    }
}

