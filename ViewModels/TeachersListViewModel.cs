using TutorLinkClient.Services;
using TutorLinkClient.Models;
using System.Collections.ObjectModel;


namespace TutorLinkClient.ViewModels;

public class TeachersListViewModel : ViewModelBase
{
    private TutorLinkWebAPIProxy proxy;
    private IServiceProvider serviceProvider;

    public ObservableCollection<TeacherDTO> TeachersList { get; set; }

    public TeachersListViewModel()
    {
        GetAllTeachers();
    }
    private async void GetAllTeachers()
    {
        List<TeacherDTO> l   = await proxy.GetAllTeachers();
        TeachersList = new ObservableCollection<TeacherDTO>();

        foreach (TeacherDTO t in l)
        {
            TeachersList.Add(t);
        }
    }




}