using TutorLinkClient.ViewModels;

namespace TutorLinkClient.Views;

public partial class ChatStudent : ContentPage
{
	public ChatStudent(ChatStudentViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}