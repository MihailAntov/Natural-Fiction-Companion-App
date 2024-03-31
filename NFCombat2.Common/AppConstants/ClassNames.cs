using NFCombat2.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Common.AppConstants
{
    public static class ClassNames
    {
        public static Dictionary<PlayerClass, string> EnglishClassNames = new Dictionary<PlayerClass, string>()
        {
            {PlayerClass.None, "None" },
            {PlayerClass.Soldier, "Soldier" },
            {PlayerClass.SpecOps, "Spec Ops" },
            {PlayerClass.Engineer, "Engineer" },
            {PlayerClass.Hacker, "Hacker" },
        };
    }
}
