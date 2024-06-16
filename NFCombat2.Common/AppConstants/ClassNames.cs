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
            {PlayerClass.None, "No class" },
            {PlayerClass.Soldier, "Soldier" },
            {PlayerClass.SpecOps, "Spec Ops" },
            {PlayerClass.Engineer, "Engineer" },
            {PlayerClass.Hacker, "Hacker" },
        };

        public static Dictionary<PlayerClass, string> BulgarianClassNames = new Dictionary<PlayerClass, string>()
        {
            {PlayerClass.None, "Без клас" },
            {PlayerClass.Soldier, "Войник" },
            {PlayerClass.SpecOps, "Специален отряд" },
            {PlayerClass.Engineer, "Отдел по поддръжка" },
            {PlayerClass.Hacker, "Информационни войски" },
        };
    }
}
