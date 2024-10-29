using TutorLinkClient.ViewModels;

namespace TutorLinkClient.Views;

public partial class Login : ContentPage
{
	public Login(LoginViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();


	}
}
