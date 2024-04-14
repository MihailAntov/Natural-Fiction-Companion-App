using NFCombat2.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.SpecOps
{
    public class Sprint : Technique
    {
        public override string Name { get; set; }
        public override int HealthThreshold => 30;
        public override TechniqueType Type => TechniqueType.Sprint;
    }
}
