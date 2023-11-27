

using NFCombat2.Common.Enums;

namespace NFCombat2.Data.Entities.Items
{
    public class WeaponEntity
    {
        public Accuracy Accuracy { get; set; }
        public string Label { get; set; }
        public int MaxRange { get; set; }
        public int MinRange { get; set; }
        public bool AreaOfEffect { get; set; } = false;
        public int DamageDice { get; set; }
        public int FlatDamage { get; set; }
        public int Weight { get; set; }
        public int CooldownPerShot { get; set; } = 1;
        public int ShotsPerTurn { get; set; } = 1;
        public List<int> ModificationIds { get; set; } = new List<int>();  

        public string Name { get; set; }
        public bool IsInvention { get; set; } = false;

    }
}
