using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Items.Equipments;

namespace NFCombat2.Models.Items.Weapons
{
    public class Weapon : IAddable
    {
        public Accuracy Accuracy { get; set; }
        public int Id { get; set; }
        public int BonusAccuracy {get; set;}
        public Accuracy EffectiveAccuracy => Accuracy + BonusAccuracy;
        //public string Label { get; set; }
        public int MaxRange { get; set; }
        public int EffectiveMaxRange => MaxRange + BonusMaxRange;
        public int BonusMaxRange { get; set; }
        public int MinRange { get; set; }
        public bool AreaOfEffect { get; set; } = false;
        public int CritMultiplier { get; set; } = 2;
        public int DamageDice { get; set; }
        public int FlatDamage { get; set; }
        public int Weight { get; set; }
        public int RemainingCooldown { get; set; } = 0;
        public int CooldownPerShot { get; set; } = 1;
        public int ShotsPerTurn { get; set; } = 1;
        public ICollection<WeaponModification> Modifications { get; set; } = new HashSet<WeaponModification>();

        public string Name { get; set; }
        public bool IsInvention { get; set; } = false;
        public Hand Hand { get; set; }
        public ItemType ItemType { get; set; }
        public bool AlwaysHits { get; set; } = false;

        public int Durability { get; set; } = 100;
        public int Quantity { get; set; } = 1;
        public string Image { get; set; } = string.Empty;
    }
}
