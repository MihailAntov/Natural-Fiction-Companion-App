﻿

using NFCombat2.Common.Enums;

namespace NFCombat2.Models.Items.Weapons
{
    public class WeaponConfig
    {
        public Accuracy Accuracy { get; set; }
        public bool AlwaysHits { get; set; } = false;
        public int Id { get; set; }
        public string Label { get; set; }
        public int MaxRange { get; set; }
        public int MinRange { get; set; }
        public bool AreaOfEffect { get; set; } = false;
        public int DamageDice { get; set; }
        public int FlatDamage { get; set; }
        public int Weight { get; set; }
        public int CooldownPerShot { get; set; } = 1;
        public int CritMultiplier { get; set; } = 2;
        public int ShotsPerTurn { get; set; } = 1;
        public string Name { get; set; }
        public bool IsInvention { get; set; } = false;
        public WeaponSpecial WeaponSpecial { get; set; } = WeaponSpecial.None;
        public int ExtraStrength { get; set; } = 0;
        public string Image { get; set; } = string.Empty;
        public int Durability { get; set; } = 100;
        
    }
}
