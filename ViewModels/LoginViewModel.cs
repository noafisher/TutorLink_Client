using TutorLinkClient.Services;

namespace TutorLinkClient.ViewModels;

public class LoginViewModel : ViewModelBase
{
	private string name;
	private string password;

	public string Name{ get { return name; } set { name = value; OnPropertyChanged(); } }
	public string Password{ get { return password; } set { password = value; OnPropertyChanged(); } }
    public Command LoginCommand { get; set; }

	private TutorLinkWebAPIProxy proxy;
	public LoginViewModel(TutorLinkWebAPIProxy proxy)
	{
		this.proxy = proxy;
		LoginCommand = new Command(OnLogin);
	}
    
	public void OnLogin()
	{

	}

}