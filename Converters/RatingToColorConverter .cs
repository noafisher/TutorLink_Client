using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorLinkClient.Converters
{
    class RatingToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                int rating = 0;
                int position = 0;

                if (value != null)
                    int.TryParse(value.ToString(), out rating);

                if (parameter != null)
                    int.TryParse(parameter.ToString(), out position);

                // If the star position is less than or equal to the current rating, show it as gold
                if (position <= rating)
                    return Colors.Gold; // Gold/yellow for selected stars

                // Otherwise show it as gray
                return Colors.LightGray; // Light gray for unselected stars
            }
            catch
            {
                // Default color in case of errors
                return Colors.Gray;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

