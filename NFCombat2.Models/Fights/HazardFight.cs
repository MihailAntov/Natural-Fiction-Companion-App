using NFCombat2.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.Fights
{
    public class HazardFight : SkillCheckFight
    {
        public HazardFight(IList<Enemy> enemies) : base(enemies, Common.Enums.CheckType.Swamp)
        {
            Type = Common.Enums.FightType.Hazard;
        }

        public override void CheckWinCondition()
        {
            if(!Enemies.Any(e=> e.Health > 0))
            {
                Result = Common.Enums.FightResult.Won;
            }
        }

        public override IList<ICombatAction> EnemyActions()
        {
            var result = new List<ICombatAction>();
            return result;
        }
    }
}
