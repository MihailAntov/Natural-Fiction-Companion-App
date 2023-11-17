using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Items.Equipments;

namespace NFCombat2.Models.Items.Weapons
{
    public class Weapon : IAddable
    {
        public Accuracy Accuracy { get; set; }
        public int BonusAccuracy {get; set;}
        public Accuracy EffectiveAccuracy => Accuracy + BonusAccuracy;
        public string Label { get; set; }
        public int MaxRange { get; set; }
        public int EffectiveMaxRange => MaxRange + BonusMaxRange;
        //TODO change variable from maxRange to effectiveMaxRange in optionService - GetTargets() and wherever else is needed
        public int BonusMaxRange { get; set; }
        public int MinRange { get; set; }
        public bool AreaOfEffect { get; set; }
        public int DamageDice { get; set; }
        public int FlatDamage { get; set; }
        public int Distance { get; set; }

        public int Weight { get; set; }
        public int RemainingCooldown { get; set; }
        public int CooldownPerShot { get; set; } = 1;
        public int ShotsPerTurn { get; set; } = 1;
        public ICollection<WeaponModification> Modifications { get; set; } = new HashSet<WeaponModification>();

        public string Name { get; set; }
    }
}
