using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorLinkClient.Models;
using TutorLinkClient.Services;
using TutorLinkClient.Views;

namespace TutorLinkClient.ViewModels
{
    public class AdminViewModel:ViewModelBase
    {
        //reports
        private ObservableCollection<ReportDTO> reports;
        public ObservableCollection<ReportDTO> Reports
        {
            get
            {
                return reports;
            }
            set
            {
                reports = value;
                OnPropertyChanged();
            }
        }

        //students and teachers
        private ObservableCollection<StudentDTO> students;
        public ObservableCollection<StudentDTO> Students
        {
            get
            {
                return students;
            }
            set
            {
                students = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<TeacherDTO> teachers;
        public ObservableCollection<TeacherDTO> Teachers
        {
            get
            {
                return teachers;
            }
            set
            {
                teachers = value;
                OnPropertyChanged();
            }
        }

        public Command DeleteReport { get; set; }
        public Command BlockUser { get; set; }

        private async void OnDeleteReport(ReportDTO r)
        {
            //this function calls the API to delete the report and if it is successful it will remove the report from the list
            bool success = await proxy.ProcessReport(r.ReportId);
            if (!success)
                await Shell.Current.DisplayAlert("Error", "Report was not deleted. Try again later", "Ok");
            else
                Reports.Remove(r);
        }
        private async void OnBlockUser(ReportDTO r)
        {
            //this function calls the API to block the user and if it is successful it will remove the report from the list
            bool success = false;
            if (r.ReportedByStudent)
            {
                success = await proxy.BlockTeacher(r.TeacherId);
            }
            else
            {
                success = await proxy.BlockStudent(r.StudentId);
            }

            if (success)
            {
                OnDeleteReport(r);
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "User was not blocked. Try again later", "Ok");
            }
        }

        private async void ReadReports()
        {
            //in this function we call the API to get the reports that are not processed and we add them to the list of reports
            List<ReportDTO> list = await proxy.GetReportsNotProcessed();
            if (list != null)
                Reports = new ObservableCollection<ReportDTO>(list);
        }

        private TutorLinkWebAPIProxy proxy;
        public AdminViewModel(TutorLinkWebAPIProxy proxy)
        {
            this.proxy = proxy;
            Reports = new ObservableCollection<ReportDTO>();
            DeleteReport = new Command<ReportDTO>(OnDeleteReport);
            BlockUser = new Command<ReportDTO>(OnBlockUser);
            Students = new ObservableCollection<StudentDTO>();
            Teachers = new ObservableCollection<TeacherDTO>();
            ReadReports();
            ReadTeachers();
            ReadStudents();
        }

        //select a student or teacher and navigate to the profile page of the selected user
        private StudentDTO selectedStudent;
        public StudentDTO SelectedStudent
        {
            get
            {
                return selectedStudent;
            }
            set
            {
                selectedStudent = value;
                if (value != null)
                {
                    OnSelectedUser();
                }
                
                OnPropertyChanged();
            }
        }

        private TeacherDTO selectedTeacher;
        public TeacherDTO SelectedTeacher
        {
            get
            {
                return selectedTeacher;
            }
            set
            {
                selectedTeacher = value;
                if (value != null)
                {
                    OnSelectedUser();
                }
                OnPropertyChanged();
            }
        }

        //calls the API to get students and teachers to add them to the list of students and teachers and than show it on the admin view
        private async void ReadStudents()
        {
            List<StudentDTO> s = await proxy.GetAllStudents();
            Students = new ObservableCollection<StudentDTO>(s);
        }

        private async void ReadTeachers()
        {
            List<TeacherDTO> t = await proxy.GetAllTeachers();
            Teachers = new ObservableCollection<TeacherDTO>(t);
        }

        //this function is called when the user selects a student or teacher and it will navigate to the profile page of the selected user
        private async void OnSelectedUser()
        {
            if (SelectedStudent != null)
            {
                var navParam = new Dictionary<string, Object>
                {
                        { "TheStudentObject", SelectedStudent}
                };
                await Shell.Current.GoToAsync("AdminProfile", navParam);
            }
                
            if (SelectedTeacher != null)
            {
                var navParam = new Dictionary<string, Object>
                {
                        { "TheTeacherObject", SelectedTeacher}
                };
                await Shell.Current.GoToAsync("AdminProfile", navParam);
            }

            SelectedStudent = null;
            SelectedTeacher = null;
        }
    }
}
