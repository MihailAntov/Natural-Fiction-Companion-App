using NFCombat2.Common.Enums;

namespace NFCombat2.Data.Models.Items
{
    public class Modification
    {
        public string Name { get; set; } = "Лазерен мерник";
        public ModificationType Type { get; set; } = ModificationType.Accuracy;
    }
}
