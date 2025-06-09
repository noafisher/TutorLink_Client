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
            TimeOfLesson = DateTime.Now.Date;
            ReadSubjects();
        }
        #region lesson name

        private bool showLessonNameError;

        public bool ShowLessonNameError
        {
            get => showLessonNameError;
            set
            {
                showLessonNameError = value;
                OnPropertyChanged("ShowLessonNameError");
            }
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

        private string lessonNameError;

        public string LessonNameError
        {
            get => lessonNameError;
            set
            {
                lessonNameError = value;
                OnPropertyChanged("FirstNameError");
            }
        }

        private void ValidateLessonName()
        {
            this.LessonNameError = "Lesson Name is required!";
            this.ShowLessonNameError = string.IsNullOrEmpty(LessonName);
        }


        #endregion

        #region command 
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
        #endregion 

        //subject teacher 

        
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

        #region  validation
        private bool showSubjectError;

        public bool ShowSubjectError
        {
            get => showSubjectError;
            set
            {
                showSubjectError = value;
                OnPropertyChanged();
            }
        }
        private string subjectError;

        public string SubjectError

        {
            get => subjectError;
            set
            {
                subjectError = value;
                OnPropertyChanged();
            }
        }

        private void ValidateSubject()
        {
            this.SubjectError = "Subject must be selected";
            this.ShowSubjectError = Subject == null;
        }
        #endregion

        
        // student
        private StudentDTO student;
        public StudentDTO Student
        {
            get { return student; }
            set
            {
                student = value;
                StudentName = student.DisplayName;
                OnPropertyChanged();
            }
        }
         #region validation 
        private bool showStudentError;

        public bool ShowStudentError
        {
            get => showStudentError;
            set
            {
                showStudentError = value;
                OnPropertyChanged();
            }
        }
        private string studentError;

        public string StudentError

        {
            get => studentError;
            set
            {
                studentError = value;
                OnPropertyChanged();
            }
        }

        private void ValidateStudent()
        {
            this.SubjectError = "Student must be selected";
            this.ShowSubjectError = Student == null;
        }
    #endregion


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

        // hour 
        private TimeSpan hour;

        public TimeSpan Hour
        {
            get { return hour; }
            set
            {
                hour = value;
                OnPropertyChanged();
            }
        }
        
        #region validation date

        private bool showHourError;

        public bool ShowHourError
        {
            get => showHourError;
            set
            {
                showHourError = value;
                OnPropertyChanged();
            }
        }
        private string hourError;

        public string HourError

        {
            get => hourError;
            set
            {
                hourError = value;
                OnPropertyChanged();
            }
        }

        private void ValidateHour()
        { 
            this.SubjectError = "Hour must be selected";
            this.ShowSubjectError = hour == null;
        }

        #endregion

        #region hour validation
        private bool showDateError;

        public bool ShowDateError
        {
            get => showDateError;
            set
            {
                showDateError = value;
                OnPropertyChanged();
            }
        }
        private string dateError;

        public string DateError

        {
            get => dateError;
            set
            {
                dateError = value;
                OnPropertyChanged();
            }
        }

        private void ValidateDate()
        {
            this.SubjectError = "Date must be in the future";
            this.ShowSubjectError = timeOfLesson > DateTime.Today;
        }

        #endregion 
        private string studentName;
        public string StudentName
        {
            get { return studentName; }
            set
            {
                studentName = value;
                if (student == null || student.DisplayName != value)
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

        //this function is called when the user types in the student name field and it will search for the students that match the name 
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
            // validation actions 
            ValidateDate();
            ValidateLessonName();
            ValidateStudent();
            ValidateSubject();

            DateTime combinedDateTime = TimeOfLesson.Date.Add(Hour);

            if (Student != null)
            {
                // create lesson object and set the properties
                Lesson lesson = new Lesson()
                {
                    StudentId = Student.StudentId,
                    TeacherId = ((App)Application.Current).LoggedInTeacher.TeacherId,
                    SubjectId = Subject.SubjectId,
                    TimeOfLesson = combinedDateTime
                };

                // send the lesson to the server and check if it was added successfully
                lesson = await proxy.AddLessonAsync(lesson);
                if (lesson != null)
                {
                    await Shell.Current.DisplayAlert("Add Lesson", "Lesson was added successfully", "Ok");
                    await Shell.Current.Navigation.PopAsync();
                }
                else
                {
                    await Shell.Current.DisplayAlert("Add Lesson", "Lesson was NOT added!", "Ok");

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
