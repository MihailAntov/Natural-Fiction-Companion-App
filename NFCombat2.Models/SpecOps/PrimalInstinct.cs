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
    internal class PrimalInstinct : Technique, IModifyResolution
    {
        public override string Name { get; set; }
        public override int HealthThreshold => 10;
        public override TechniqueType Type => TechniqueType.PrimalInstinct;

        public Task<List<ICombatAction>> Modify(ICombatResolution resolution)
        {
            List<ICombatAction> followUp = new List<ICombatAction>();
            if(resolution is DealDamage ranged)
            {
                foreach(var target in ranged.Targets)
                {
                    int amount = ranged is Crit ? ranged.Amount * 2 : ranged.Amount;
                    if(amount >= target.Health && target.Distance > 0)
                    {
                        followUp.Add(new PrimalInstinctHeal());
                    }
                }
            }
            return Task.FromResult(followUp);
        }
    }
}
