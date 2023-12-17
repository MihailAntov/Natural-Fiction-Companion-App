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
            {(FightType.Chase, FightResult.Lost),"You have lost!" },
            {(FightType.SkillCheck, FightResult.Won),"You succeeded!" },
            {(FightType.SkillCheck, FightResult.Lost),"You have failed." },
            {(FightType.Hazard, FightResult.Won),"You have won!" },
            {(FightType.Hazard, FightResult.Lost),"You have failed." },
            {(FightType.Constrained, FightResult.Won),"You have won!" },
            {(FightType.Constrained, FightResult.Lost),"You have lost!" },
            {(FightType.Virtual, FightResult.Won),"You have won!" },
            {(FightType.Virtual, FightResult.Lost),"You have lost.!" },
            {(FightType.Escape, FightResult.Won),"You've won!" },
            {(FightType.Escape, FightResult.Lost),"You have lost!" },
            {(FightType.Escape, FightResult.Escaped),"You have escaped!" },
        };
    }
}
