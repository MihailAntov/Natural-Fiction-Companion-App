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
    internal class Combo : Technique , IModifyResolution
    {
        public override string Name { get; set; }
        public override int HealthThreshold => 10;
        public override TechniqueType Type => TechniqueType.Combo;

        public Task<List<ICombatAction>> Modify(ICombatResolution resolution)
        {
            List<ICombatAction> followUps = new List<ICombatAction>();
            if(resolution is DealMeleeDamage meleeDamage)
            {
                followUps.Add(new ComboAttack(meleeDamage.Target));
            }
            return Task.FromResult(followUps);
        }
    }
}
