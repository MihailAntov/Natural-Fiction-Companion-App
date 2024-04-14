using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;

namespace NFCombat2.Models.SpecOps
{
    public abstract class Technique
    {
        public abstract string Name { get; set; }
        public abstract int HealthThreshold { get; }
        public abstract TechniqueType Type { get; }
    }
}
