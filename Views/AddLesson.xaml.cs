namespace TutorLinkClient.Views;
using TutorLinkClient.ViewModels;


public partial class AddLesson : ContentPage
{
	public AddLesson(AddLessonViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}