using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using TutorLinkClient.Models;
using TutorLinkClient.Services;

namespace TutorLinkClient.ViewModels;

public class ChatStudentViewModel : ViewModelBase
{
	private ObservableCollection<MessagesFromTeacher> messages;
	public ObservableCollection<MessagesFromTeacher> Messages
	{ 
		get
		{ return messages; } 
		set 
		{ 
			messages = value; 
			OnPropertyChanged(); 
		}
	}

	private MessagesFromTeacher selectedTeacher;
	public MessagesFromTeacher SelectedTeacher
	{
		get { return selectedTeacher; }
		set
		{
			selectedTeacher = value;
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

    public ChatStudentViewModel( TutorLinkWebAPIProxy proxy, IServiceProvider serviceProvider)
	{
		this.proxy = proxy;
		this.serviceProvider = serviceProvider;
		Messages = ((AppShellViewModel)(Shell.Current.BindingContext)).MessagesFromTeacher;
		SelectedTeacher = null;

		
	}
	private async void OnGoToChat()
	{
		if (SelectedTeacher != null)
		{
            var navParam = new Dictionary<string, object>
            {
                    { "messages", SelectedTeacher.Messages },
                    { "teacher", SelectedTeacher.Teacher},
                    { "student", ((App)Application.Current).LoggedInStudent}
            };
            await Shell.Current.GoToAsync("ChatDetails", navParam);
			SelectedTeacher = null;
        }
        //TODO: Open the chat details page and transfer the selected object
        
    }

}