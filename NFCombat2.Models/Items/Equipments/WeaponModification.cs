using NFCombat2.Common.Enums;
using NFCombat2.Models.Items.Weapons;

namespace NFCombat2.Models.Items.Equipments
{
    public abstract class WeaponModification : Equipment
    {
        public Weapon Weapon { get; private set; }
        public AttachedTo AttachedTo { get; set; } = AttachedTo.None;
        public void AttachToWeapon(Weapon weapon)
        {
            if(Weapon != null)
            {
                UnAttachFromWeapon();
            }

            Weapon = weapon;
            AddModification(weapon);
            AttachedTo = weapon.Hand == Hand.MainHand ? AttachedTo.MainHand : AttachedTo.OffHand;
            
        }
        public void UnAttachFromWeapon()
        {
            if(Weapon != null)
            {
                RemoveModification(Weapon);
                Weapon = null;
                AttachedTo = AttachedTo.None;
            }
            
        }
        protected abstract void AddModification(Weapon weapon);
        protected abstract void RemoveModification(Weapon weapon);

    }
}
