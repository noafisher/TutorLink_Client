
using TutorLinkClient.ViewModels;
namespace TutorLinkClient.Views;

public partial class ProfilePage : ContentPage
{
	public ProfilePage(ProfilePageViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}