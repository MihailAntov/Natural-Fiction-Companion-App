
using NFCombat2.Common.Enums;
using System.Globalization;
using NFCombat2.Models.Dice;


namespace NFCombat2.Helpers
{
    public class DiceImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int numberOfDice = (int)value;
            return numberOfDice > 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
