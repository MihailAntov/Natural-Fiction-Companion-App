using NFCombat2.Models.Items.Weapons;

namespace NFCombat2.Models.Items.Equipments
{
    public abstract class WeaponModification : Equipment
    {
        public Weapon Weapon { get; private set; }
        public void AttachToWeapon(Weapon weapon)
        {
            if(Weapon == null)
            {
                Weapon = weapon;
                AddModification(weapon);
            }
        }
        public void UnAttachFromWeapon()
        {
            if(Weapon != null)
            {
                RemoveModification(Weapon);
                Weapon = null;
            }
        }
        protected abstract void AddModification(Weapon weapon);
        protected abstract void RemoveModification(Weapon weapon);

    }
}
