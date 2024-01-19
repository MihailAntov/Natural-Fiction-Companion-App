using NFCombat2.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Common.AppConstants
{
    public static class CraftResults
    {
        public static Dictionary<CraftResult, string> EnglishCraftResults = new Dictionary<CraftResult, string>()
        {
            {CraftResult.Correct, "Successfully crafted item." },
            {CraftResult.Incorrect, "Incorrect formula." }
        };
    }
}
