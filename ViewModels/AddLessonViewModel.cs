using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorLinkClient.Services;
using TutorLinkClient.Models;
using TutorLinkClient.Views;
using System.Windows.Input;

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

        private ICommand addLessonCommand;
        public ICommand AddLessonCommand
        {
            get { return addLessonCommand; }

            set
            {
                addLessonCommand = value;
                OnPropertyChanged();
            }
        }

        private SubjectDTO subject;
        public SubjectDTO Subject
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



         

    }
}
