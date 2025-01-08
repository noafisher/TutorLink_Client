using TutorLinkClient.ViewModels;

namespace TutorLinkClient.Views;

public partial class TeachersList : ContentPage
{
	public TeachersList(TeachersListViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}