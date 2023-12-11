

using NFCombat2.Models.Contracts;
using System.Globalization;

namespace NFCombat2.Helpers
{
    internal class InventoryActiveConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is IInventoryActiveItem item)
            {
                return true;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
