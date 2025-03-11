
using TutorLinkClient.ViewModels;
namespace TutorLinkClient.Views;

public partial class Calendar : ContentPage
{
	public Calendar(CalendarViewModel calendarViewModel)
	{
		this.BindingContext = calendarViewModel;
		InitializeComponent();
	}
}