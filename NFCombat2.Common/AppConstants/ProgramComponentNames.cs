using NFCombat2.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Common.AppConstants
{
    public static class ProgramComponentNames
    {
        public static Dictionary<ProgramComponentType, string> EnglishProgramComponentNames =
            new Dictionary<ProgramComponentType, string>()
            {
                {ProgramComponentType.Send, "Send" },
                {ProgramComponentType.Receive, "Receive" },
                {ProgramComponentType.Direct, "Direct" },
                {ProgramComponentType.Extend, "Extend" },
                {ProgramComponentType.Optimize, "Optimize" },
                {ProgramComponentType.Analyze, "Analyze" },
                {ProgramComponentType.Unlock, "Unlock" },
                {ProgramComponentType.Fix, "Repair" },
                {ProgramComponentType.Move, "Move" },
            };

        public static Dictionary<ProgramComponentType, string> BulgarianProgramComponentNames =
            new Dictionary<ProgramComponentType, string>()
            {
                {ProgramComponentType.Send, "Изпрати" },
                {ProgramComponentType.Receive, "Получи" },
                {ProgramComponentType.Direct, "Насочи" },
                {ProgramComponentType.Extend, "Удължи" },
                {ProgramComponentType.Optimize, "Оптимизирай" },
                {ProgramComponentType.Analyze, "Анализирай" },
                {ProgramComponentType.Unlock, "Отключи" },
                {ProgramComponentType.Fix, "Поправи" },
                {ProgramComponentType.Move, "Премести" },
            };
    }
}


//Receive,
//        Send,
//        Direct,
//        Extend,
//        Optimize,
//        Analyze,
//        Unlock,
//        Fix,
//        Move