using TutorLinkClient.ViewModels;

namespace TutorLinkClient.Views;

public partial class ReportUser : ContentPage
{
	public ReportUser(ReportUserViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}