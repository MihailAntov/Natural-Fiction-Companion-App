using NFCombat2.Models.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.Items.Equipments
{
    public class GasOperatedReloadingSystem : WeaponModification
    {
        public int ExtraAttacks { get; set; }
        public GasOperatedReloadingSystem()
        {
            ExtraAttacks = 1;
        }
        protected override void AddModification(Weapon weapon)
        {
            weapon.ShotsPerTurn += ExtraAttacks;
        }

        protected override void RemoveModification(Weapon weapon)
        {
            weapon.ShotsPerTurn -= ExtraAttacks;
        }
    }
}
