using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Items.Equipments;
using NFCombat2.Models.Items.Weapons;

namespace NFCombat2.Models.CombatResolutions
{
    public class EquippedToWeapon : ICombatResolution
    {
        private WeaponModification _modification;
        private Weapon _weapon;
        public EquippedToWeapon(WeaponModification modification, Weapon weapon)
        {
            _modification = modification;
            _weapon = weapon;
        }
        public MessageType MessageType => MessageType.EquippedToWeapon;

        public string[] MessageArgs => new string[2] { _modification.Name, _weapon.Name };

        public Task Resolve(Fight fight)
        {
            return Task.CompletedTask;
        }
    }
}
