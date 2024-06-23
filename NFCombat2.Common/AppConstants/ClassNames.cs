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
            {PlayerClass.Soldier, "Elite Squad" },
            {PlayerClass.SpecOps, "Spec Ops" },
            {PlayerClass.Engineer, "Maintenance Dept." },
            {PlayerClass.Hacker, "Information Warfare" },
        };

        public static Dictionary<PlayerClass, string> BulgarianClassNames = new Dictionary<PlayerClass, string>()
        {
            {PlayerClass.None, "Без клас" },
            {PlayerClass.Soldier, "Елитен отряд" },
            {PlayerClass.SpecOps, "Специални части" },
            {PlayerClass.Engineer, "Отдел по поддръжка" },
            {PlayerClass.Hacker, "Информационни войски" },
        };
    }
}
