

using NFCombat2.Common.Enums;

namespace NFCombat2.Data.Models.Items
{
    public class Weapon
    {
        public string Name { get; set; } = "ОРЪЖИЕ";
        public int Weight { get; set; } = 1;
        public int DiceDamage { get; set; } = 1;
        public int FlatDamage { get; set; } = 0;
        public Accuracy Accuracy { get; set; } = Accuracy.S;
        public WeaponSpecial Special { get; set; } = WeaponSpecial.None;
    }
}
