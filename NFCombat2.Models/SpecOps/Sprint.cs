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
    public class Sprint : Technique, IModifyResolution
    {
        public override string Name { get; set; }
        public override int HealthThreshold => 30;
        public override TechniqueType Type => TechniqueType.Sprint;

        public Task<List<ICombatAction>> Modify(ICombatResolution resolution)
        {
            if(resolution is ChangeDistance movement)
            {
                movement.Amount = -6;
                movement.MessageArgs[1]  = (int.Parse(movement.MessageArgs[1]) - 3).ToString();
                
            }
            return Task.FromResult(new List<ICombatAction>());
        }
    }
}
