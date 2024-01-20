
using NFCombat2.Models.Player;
using System.Globalization;


namespace NFCombat2.Helpers
{
    internal class PlayerSelectedBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((Player)value) != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
