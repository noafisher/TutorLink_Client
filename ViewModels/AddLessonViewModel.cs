using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorLinkClient.Services;
using TutorLinkClient.Models;
using TutorLinkClient.Views;

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

         

    }
}
