

using NFCombat2.Common.Enums;
using NFCombat2.Models.Player;
using System.Globalization;

namespace NFCombat2.Helpers
{
    public class PlayerConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if(values!= null && values.Length == 2)
            {
                string name = values[0].ToString();
                PlayerClass playerClass = values[1] == null ? PlayerClass.None : (PlayerClass)Enum.Parse(typeof(PlayerClass), values[1].ToString());
                Player player = new Player() { Name = name };
                switch (playerClass)
                {
                    case PlayerClass.None:
                        break;
                    case PlayerClass.Hacker:
                        player.Class = PlayerClass.Hacker;
                        break;
                    case PlayerClass.Soldier:
                        player.Class = PlayerClass.Soldier;
                        break;
                    case PlayerClass.SpecOps:
                        player.Class = PlayerClass.SpecOps;
                        break;
                    case PlayerClass.Engineer:
                        player.Class = PlayerClass.Engineer;
                        break;
                }
                return player;
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
