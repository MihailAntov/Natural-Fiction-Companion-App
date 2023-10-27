using NFCombat2.Common.Enums;

namespace NFCombat2.Data.Models.Items
{
    public class Part
    {
        public string Description { get; set; } = "Горивна Клетка";
        public string Letter { get; set; } = "а";
        public int Code { get; set; } = 2;
        public PartType Type { get; set; } = PartType.ReactiveAgent;
        public int Quantity { get; set; }
    }
}


