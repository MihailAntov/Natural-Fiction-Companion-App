using NFCombat2.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.SpecOps
{
    internal class BattleMastery : Technique
    {
        public override string Name { get; set; }
        public override int HealthThreshold => 5;
        public override TechniqueType Type => TechniqueType.BattleMastery;
    }
}
