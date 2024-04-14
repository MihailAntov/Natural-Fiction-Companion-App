using NFCombat2.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.SpecOps
{
    internal class Perfectionism : Technique
    {
        public override string Name { get; set; }
        public override int HealthThreshold => 1;
        public override TechniqueType Type => TechniqueType.Perfectionism;
    }
}
