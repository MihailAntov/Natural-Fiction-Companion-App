using NFCombat2.Models.Contracts;
using NFCombat2.Models.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.Items.Equipments
{
    public class LaserSight : WeaponModification
    {
        public int BonusAccuracy { get; set; }
        public LaserSight()
        {
            BonusAccuracy = 1;
            Image = "crosshair";
        }

        protected override void AddModification(Weapon weapon)
        {
            weapon.BonusAccuracy += BonusAccuracy;   
        }

        protected override void RemoveModification(Weapon weapon)
        {
            weapon.BonusAccuracy -= BonusAccuracy;
        }

        protected override void UpdateIconFlags(Weapon weapon)
        {
            weapon.HasLaserSight = weapon.Modifications.OfType<LaserSight>().Any();
        }
    }
}
