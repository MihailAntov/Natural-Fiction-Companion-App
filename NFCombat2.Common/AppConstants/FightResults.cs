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
            {(FightType.Virtual, FightResult.Won),"You have won!" },
            {(FightType.Virtual, FightResult.Lost),"You have lost.!" },
            {(FightType.Stationary, FightResult.Won),"You have won!" },
            {(FightType.Stationary, FightResult.Lost),"You have lost." },
            {(FightType.Escape, FightResult.Won),"You've won!" },
            {(FightType.Escape, FightResult.Lost),"You have lost!" },
            {(FightType.Escape, FightResult.Escaped),"You have escaped!" },
        };

        public static Dictionary<(FightType, FightResult), string> BulgarianFightResults = new Dictionary<(FightType, FightResult), string>()

        {
            {(FightType.Regular, FightResult.Won),"Спечели битката!" },
            {(FightType.Regular, FightResult.Lost),"Загуби битката." },
            {(FightType.Chase, FightResult.Won),"Спечели битката!" },
            {(FightType.Chase, FightResult.Lost),"Загуби битката." },
            {(FightType.SkillCheck, FightResult.Won),"Успя!" },
            {(FightType.SkillCheck, FightResult.Lost),"Провали се." },
            {(FightType.Hazard, FightResult.Won),"Успя!" },
            {(FightType.Hazard, FightResult.Lost),"Провали се." },
            {(FightType.Virtual, FightResult.Won),"Спечели битката!" },
            {(FightType.Virtual, FightResult.Lost),"Загуби битката." },
            {(FightType.Stationary, FightResult.Won),"Спечели битката!" },
            {(FightType.Stationary, FightResult.Lost),"Загуби битката." },
            {(FightType.Escape, FightResult.Won),"Спечели битката!" },
            {(FightType.Escape, FightResult.Lost),"Загуби битката." },
            {(FightType.Escape, FightResult.Escaped),"Успя да избягаш!" },
        };
    }
}
