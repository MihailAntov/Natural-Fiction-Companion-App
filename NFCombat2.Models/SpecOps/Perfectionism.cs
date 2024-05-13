using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.SpecOps
{
    internal class Perfectionism : Technique, IModifyResolution
    {
        public override string Name { get; set; }
        public override int HealthThreshold => 1;
        public override TechniqueType Type => TechniqueType.Perfectionism;

        public Task<List<ICombatAction>> Modify(ICombatResolution resolution)
        {
            if(resolution is Crit crit)
            {
                crit.CritMultiplier *= 2;
            }

            return Task.FromResult(new List<ICombatAction>());
        }
    }
}
