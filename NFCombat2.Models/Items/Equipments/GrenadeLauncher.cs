
using NFCombat2.Common.Helpers;
using NFCombat2.Models.Actions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Items.Weapons;

namespace NFCombat2.Models.Items.Equipments
{
    public class GrenadeLauncher : WeaponModification
    {
        public int BonusDamageDice { get; set; }
        public GrenadeLauncher()
        {
            BonusDamageDice = 1;
            Name = "Grenade Launcher";
        }

        protected override void AddModification(Weapon weapon)
        {
            weapon.DamageDice += BonusDamageDice;
        }

        protected override void RemoveModification(Weapon weapon)
        {
            weapon.DamageDice -= BonusDamageDice;
        }
    }
}
