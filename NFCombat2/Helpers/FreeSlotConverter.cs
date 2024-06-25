using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Helpers
{
    class FreeSlotConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int limit = int.Parse(parameter.ToString());
            
            if(values.Length == 2 && values[0] is int quantity && values[1] is int currentItems) 
            {
                int max = limit - (currentItems - quantity);
                if(max <= 0)
                {
                    return quantity > 0 ? quantity : 1;
                }
                return quantity % 2 == 0 ? max : max +1;
            }
            return limit;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
