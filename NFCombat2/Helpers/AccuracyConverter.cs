

using NFCombat2.Common.Enums;
using System.Globalization;

namespace NFCombat2.Helpers
{
    public class AccuracyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var accuracy = (Accuracy)value;
            switch(accuracy)
            {
                case Accuracy.S:
                    return "S";
                case Accuracy.A:
                    return "A";
                case Accuracy.B:
                    return "B";
                case Accuracy.C:
                    return "C";
                case Accuracy.D:
                    return "D";
                case Accuracy.E:
                default:
                    return "E";
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
