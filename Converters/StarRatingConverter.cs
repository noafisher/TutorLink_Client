using System.Globalization;

namespace TutorLinkClient.Converters
{
    public class StarRatingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int rating = 0;
            if (value != null && int.TryParse(value.ToString(), out int parsedRating))
                rating = parsedRating;

            int starPosition = 0;
            if (parameter != null && int.TryParse(parameter.ToString(), out int parsedPosition))
                starPosition = parsedPosition;

            return starPosition <= rating ?
                Application.Current.Resources["starButtonStyle"] :
                Application.Current.Resources["emptyStarButtonStyle"];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}