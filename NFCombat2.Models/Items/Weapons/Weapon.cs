using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Items.Equipments;

namespace NFCombat2.Models.Items.Weapons
{
    public abstract class Weapon : IAddable
    {
        public abstract Accuracy Accuracy { get; set; }
        public int Id { get; set; }
        public int BonusAccuracy {get; set;}
        public Accuracy EffectiveAccuracy => Accuracy + BonusAccuracy;
        public abstract string Label { get; set; }
        public abstract int MaxRange { get; set; }
        public int EffectiveMaxRange => MaxRange + BonusMaxRange;
        public int BonusMaxRange { get; set; }
        public abstract int MinRange { get; set; }
        public bool AreaOfEffect { get; set; } = false;
        public abstract int DamageDice { get; set; }
        public abstract int FlatDamage { get; set; }
        public abstract int Weight { get; set; }
        public int RemainingCooldown { get; set; } = 0;
        public int CooldownPerShot { get; set; } = 1;
        public int ShotsPerTurn { get; set; } = 1;
        public ICollection<WeaponModification> Modifications { get; set; } = new HashSet<WeaponModification>();

        public abstract string Name { get; set; }
        public bool IsInvention { get; set; } = false;
    }
}
