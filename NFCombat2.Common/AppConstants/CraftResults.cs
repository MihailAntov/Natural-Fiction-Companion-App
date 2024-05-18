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
            {CraftResult.Correct, "Successfully crafted {0}." },
            {CraftResult.Incorrect, "Incorrect formula." }
        };

        public static Dictionary<CraftResult, string> BulgarianCraftResults = new Dictionary<CraftResult, string>()

        {
            {CraftResult.Correct, "Успешно изобрети {0}." },
            {CraftResult.Incorrect, "Грешна формула." }

        };
    }
}
