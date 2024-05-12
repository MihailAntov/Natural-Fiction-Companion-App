using NFCombat2.Common.Enums;
using NFCombat2.Models.Actions;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.SpecOps
{
    internal class Resilience : Technique, IModifyResolution
    {
        public override string Name { get; set; }
        public override int HealthThreshold => 15;
        public override TechniqueType Type => TechniqueType.Resilience;

        public Task<List<ICombatAction>> Modify(ICombatResolution resolution)
        {
            List<ICombatAction> followups = new List<ICombatAction>();
            if(resolution is EnemyDealDamage shot)
            {
                shot.Damage /= 2;
            }

            return Task.FromResult(followups);
        }
    }
}
