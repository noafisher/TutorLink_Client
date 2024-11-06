using TutorLinkClient.ViewModels;

namespace TutorLinkClient.Views;


public partial class Register : ContentPage
{
	public Register(RegisterViewModel vm)
	{
		this.BindingContext = vm;
        InitializeComponent();
	}
}