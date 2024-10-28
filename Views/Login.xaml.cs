using TutorLink_Client.ViewModels;

namespace TutorLink_Client.Views;

public partial class Login : ContentPage
{
	public Login(LoginViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();


	}
}
