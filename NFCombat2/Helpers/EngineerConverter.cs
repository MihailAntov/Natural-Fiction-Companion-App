using NFCombat2.Common.Enums;
using NFCombat2.Models.Player;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Helpers
{
    class EngineerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var playerClass = (PlayerClass)value;
            return playerClass == Common.Enums.PlayerClass.Engineer;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
