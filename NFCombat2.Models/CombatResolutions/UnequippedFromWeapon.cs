

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Items.Equipments;
using NFCombat2.Models.Items.Weapons;

namespace NFCombat2.Models.CombatResolutions
{
    public class UnequippedFromWeapon : ICombatResolution
    {
        private WeaponModification _modification;
        
        public UnequippedFromWeapon(WeaponModification modification)
        {
            _modification = modification;
            
        }
        public MessageType MessageType => MessageType.UnequippedFromWeapon;

        public string[] MessageArgs => new string[1] { _modification.Name };

        public Task Resolve(Fight fight)
        {
            return Task.CompletedTask;
        }
    }
}
