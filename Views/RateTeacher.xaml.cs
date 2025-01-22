using TutorLinkClient.ViewModels;

namespace TutorLinkClient.Views;

public partial class RateTeacher : ContentPage
{
	public RateTeacher(RateTeacherViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}