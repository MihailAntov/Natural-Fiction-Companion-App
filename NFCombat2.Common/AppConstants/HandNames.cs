using NFCombat2.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Common.AppConstants
{
    public static class HandNames
    {
        public static Dictionary<Hand, string> EnglishHandNames = new Dictionary<Hand, string>()
        {
            {Hand.MainHand, "Main hand" },
            {Hand.OffHand, "Off hand" },
        };
    }
}
