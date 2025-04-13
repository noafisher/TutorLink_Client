using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace TutorLinkClient.ViewModels
{
    public class MessageDirectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return false;

            // Get the current mode (teacher or student)
            var shellViewModel = (AppShellViewModel)(Shell.Current.BindingContext);
            bool isTeacherMode = shellViewModel.IsTeacher;

            // Get whether the message was sent by a teacher
            bool isTeacherSender = (bool)parameter;

            if (value is bool isOutgoing)
            {
                if (isOutgoing) // For outgoing messages
                {
                    // If we're in teacher mode and the message is from a teacher OR
                    // If we're in student mode and the message is NOT from a teacher
                    return (isTeacherMode && isTeacherSender) || (!isTeacherMode && !isTeacherSender);
                }
                else // For incoming messages
                {
                    // If we're in teacher mode and the message is NOT from a teacher OR
                    // If we're in student mode and the message is from a teacher
                    return (isTeacherMode && !isTeacherSender) || (!isTeacherMode && isTeacherSender);
                }
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}