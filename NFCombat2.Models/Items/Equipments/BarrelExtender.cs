using NFCombat2.Models.Contracts;
using NFCombat2.Models.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.Items.Equipments
{
    public class BarrelExtender : WeaponModification
    {
        public BarrelExtender()
        {
            BonusRange = 15;
        }
        public int BonusRange { get; set; }

        protected override void AddModification(Weapon weapon)
        {
            weapon.BonusMaxRange += BonusRange;
        }

        protected override void RemoveModification(Weapon weapon)
        {
            weapon.BonusMaxRange -= BonusRange;
        }
    }
}
