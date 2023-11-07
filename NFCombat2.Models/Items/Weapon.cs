using NFCombat2.Common.Enums;

namespace NFCombat2.Models.Items
{
    public class Weapon
    {
        public Accuracy Accuracy { get; set; }
        public string Label { get; set; }
        public int MaxRange { get; set; }
        public int MinRange { get; set; }   
        public bool AreaOfEffect { get; set; }
        public int DamageDice { get; set; }
        public int FlatDamage { get; set; }
        public int Distance { get; set; }

        public int Weight { get; set; }
        public int Cooldown { get; set; }
        public int CooldownPerShot { get; set; } = 1;
    }
}
