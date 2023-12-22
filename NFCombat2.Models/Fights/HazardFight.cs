using NFCombat2.Models.Actions;
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
        public HazardFight() : base(Common.Enums.CheckType.Swamp)
        {
            Type = Common.Enums.FightType.Hazard;
        }

        public override void CheckWinCondition()
        {
            if(!Enemies.Any(e=> e.Health > 0))
            {
                Result = Common.Enums.FightResult.Won;
            }

            if(Player.Pathogens >= Player.MaxPathogens)
            {
                Result = Common.Enums.FightResult.Lost;
            }
        }

        public override IList<ICombatAction> EnemyActions()
        {
            var result = new List<ICombatAction>();
            if(Player.Equipment.Any(e=> e.ItemType == Common.Enums.ItemType.GasMask))
            {
                result.Add(new GasMaskProtected());
            }
            else
            {
                result.Add(new SwampAttack());
            }

            return result;
        }
    }
}
