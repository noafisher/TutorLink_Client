using TutorLinkClient.Services;
using TutorLinkClient.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace TutorLinkClient.ViewModels;

public class TeachersListViewModel : ViewModelBase
{
    private TutorLinkWebAPIProxy proxy;
    private IServiceProvider serviceProvider;

    public ObservableCollection<TeacherDTO> TeachersList { get; set; }

    public TeachersListViewModel(TutorLinkWebAPIProxy proxy, IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        this.proxy = proxy;
        this.GotoChatCommand = new Command<TeacherDTO>(OnGotoChat);
        TeachersList = new ObservableCollection<TeacherDTO>();
        GetAllTeachers();
    }
    private async void GetAllTeachers()
    {
        List<TeacherDTO> l   = await proxy.GetAllTeachers();
        

        foreach (TeacherDTO t in l)
        {
            TeachersList.Add(t);
        }
    }

    public ICommand GotoChatCommand { get; set; }
    private async void OnGotoChat(TeacherDTO t)
    {
        await Shell.Current.GoToAsync("/ChatStudent");

    }




}