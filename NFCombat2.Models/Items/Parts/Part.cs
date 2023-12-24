using NFCombat2.Common.Enums;

namespace NFCombat2.Models.Items.Parts
{
    public class Part : Item
    {
        public PartType PartType { get; set; }
        public WorkCoefficient WorkCoefficient { get; set; }
    }
}
