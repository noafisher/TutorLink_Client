using TutorLinkClient.ViewModels;

namespace TutorLinkClient.Views;

public partial class ChatTeacher : ContentPage
{
	public ChatTeacher(ChatTeacherViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}