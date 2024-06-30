
using NFCombat2.Models.Contracts;

namespace NFCombat2.Models.Items.Weapons
{
    public class MeleeWeapon : Weapon, IModifyPlayer
    {
        public int ExtraStrength { get; set; }

        public void OnAdded(Player.Player player)
        {
            player.WeaponStrength += ExtraStrength;
        }

        public void OnRemoved(Player.Player player)
        {
            player.WeaponStrength -= ExtraStrength;
        }
    }
}
