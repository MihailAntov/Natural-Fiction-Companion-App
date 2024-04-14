

using NFCombat2.Common.Enums;

namespace NFCombat2.Models.SpecOps
{
    public class Anticipation : Technique
    {
        public override string Name { get; set; }
        public override int HealthThreshold => 25;
        public override TechniqueType Type => TechniqueType.Anticipation;
    }
}
