using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorLinkClient.Services;
using TutorLinkClient.Models;
using TutorLinkClient.Views;
using System.Windows.Input;
using System.Collections.ObjectModel;



namespace TutorLinkClient.ViewModels
{
    public class AddLessonViewModel : ViewModelBase
    {
        private TutorLinkWebAPIProxy proxy;
        private IServiceProvider serviceProvider;

        public AddLessonViewModel(TutorLinkWebAPIProxy proxy, IServiceProvider serviceProvider)
        {
            this.proxy = proxy;
            this.serviceProvider = serviceProvider;
            Students = new ObservableCollection<StudentDTO>();
            addLessonCommand = new Command(Save);
            Subjects = new List<TeacherSubject>();
            ReadSubjects();
        }

        private string lessonName;
        public string LessonName
        {
            get { return lessonName; }
            set
            {
                lessonName = value;
                OnPropertyChanged();
            }
        }

        private Command addLessonCommand;
        public Command AddLessonCommand
        {
            get { return addLessonCommand; }

            set
            {
                addLessonCommand = value;
                OnPropertyChanged();
            }
        }

        private List<TeacherSubject> subjects;
        public List<TeacherSubject> Subjects
        {
            get { return subjects; }
            set
            {
                subjects = value;
                OnPropertyChanged();
            }
        }

        private TeacherSubject subject;
        public TeacherSubject Subject
        {
            get { return subject; }
            set
            {
                subject = value;
                OnPropertyChanged();
            }
        }

        private DateTime timeOfLesson; 
        public DateTime TimeOfLesson
        {
            get { return timeOfLesson; }
            set
            {
                timeOfLesson = value;
                OnPropertyChanged();
            }
        }

        // student 
        private StudentDTO student;
        public StudentDTO Student
        {
            get { return student; }
            set
            {
                student = value;

                OnPropertyChanged();
            }
        }
        private string studentName;
        public string StudentName
        {
            get { return studentName; }
            set
            {
                studentName = value;
                if (student != null && student.DisplayName != value)
                {
                    PopulateStudents();
                }
                else
                    Students.Clear();
                OnPropertyChanged();
            }
        }
        private ObservableCollection<StudentDTO> students;
        public ObservableCollection<StudentDTO> Students
        {
            get { return students; }
            set
            {
                students = value;
                OnPropertyChanged();
            }
        }

        private async void PopulateStudents()
        {
            List<StudentDTO> list = await proxy.FindStudents(studentName);
            if(list != null)
            {
                Students = new ObservableCollection<StudentDTO>(list);
            }
        }

        private async void Save()
        {
            //Add validations here!!!

            if (Student != null)
            {
                Lesson lesson = new Lesson()
                {
                    StudentId = Student.StudentId,
                    TeacherId = ((App)Application.Current).LoggedInTeacher.TeacherId,
                    SubjectId = Subject.SubjectId,
                    TimeOfLesson = TimeOfLesson
                };

                lesson = await proxy.AddLessonAsync(lesson);
                if (lesson != null)
                {
                    await Shell.Current.DisplayAlert("Add Lesson", "Leson was added successfully", "Ok");
                    await Shell.Current.Navigation.PopAsync();
                }
                else
                {
                    await Shell.Current.DisplayAlert("Add Lesson", "Leson was NOT added!", "Ok");

                }

            }
            
            

        }

        private void ReadSubjects()
        {
            Subjects.Clear();
            List<TeacherSubject> list = ((App)Application.Current).LoggedInTeacher.TeacherSubjects;
            Subjects = list;
        }

         

    }
}
