using NFCombat2.Common.Enums;

namespace NFCombat2.Models
{
    public abstract class Weapon
    {
        public Accuracy Accuracy { get; set; }
        public int Range { get; set; }
        public int DamageDice { get; set; }
        public int FlatDamage { get; set; }
        public int Distance { get; set; }

        public int Weight { get; set; }
    }
}
