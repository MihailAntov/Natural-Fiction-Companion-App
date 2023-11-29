using NFCombat2.Models.Items.Weapons;


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
            weapon.Modifications.Add(this);
        }

        protected override void RemoveModification(Weapon weapon)
        {
            weapon.BonusMaxRange -= BonusRange;
            weapon.Modifications.Remove(this);
        }
    }
}
