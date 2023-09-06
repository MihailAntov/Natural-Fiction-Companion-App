using NFCombat2.Common.Enums;

namespace NFCombat2.Models
{
    public class Enemy
    {
        public int Health { get; set; }
        public int Strength { get { return (int)Math.Round(Health / 10.0); } }
        public Accuracy Accuracy { get; set; }
        public int Range { get; set; }
        public int DamageDice { get; set; }
        public int FlatDamage { get; set; }
        public int Distance { get; set; }
        public int Speed { get; set; }
    }
}
