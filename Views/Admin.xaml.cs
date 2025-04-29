using TutorLinkClient.ViewModels;

namespace TutorLinkClient.Views;

public partial class Admin : ContentPage
{
	public Admin(AdminViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}