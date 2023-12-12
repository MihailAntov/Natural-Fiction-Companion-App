using NFCombat2.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Common.AppConstants
{
    public static class FightResults
    {
        public static Dictionary<(FightType, FightResult), string> EnglishFightResults = new Dictionary<(FightType, FightResult), string>()
        {
            {(FightType.Regular, FightResult.Won),"You have won!" },
            {(FightType.Regular, FightResult.Lost),"You have lost!" },
            {(FightType.Chase, FightResult.Won),"You have won!" },
            {(FightType.Chase, FightResult.Lost),"You have won!" },
            {(FightType.Constrained, FightResult.Won),"You have won!" },
            {(FightType.Constrained, FightResult.Lost),"You have won!" },
        };
    }
}
