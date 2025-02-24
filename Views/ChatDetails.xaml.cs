using TutorLinkClient.ViewModels;

namespace TutorLinkClient.Views;

public partial class ChatDetails : ContentPage
{
	public ChatDetails(ChatDetailsViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}